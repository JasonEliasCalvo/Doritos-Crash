using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemycontroller : MonoBehaviour
{
    Animator anim;
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    NavMeshAgent agent;
    public List<Transform> PatrolPositions { get => patrolPositions; set => patrolPositions = value; }
    [SerializeField] private List<Transform> patrolPositions = new List<Transform>();
    public bool Target { get => target; set => target = value; }
    private bool target;

    public Collider[] Collide { get => collide; set => collide = value; }
    Collider[] collide;
    Collider[] collideKick;

    [SerializeField] Transform pivotCapsule1;
    [SerializeField] Transform pivotCapsule2;
    [SerializeField] Transform pivotKick;
    [SerializeField] float radio;
    [SerializeField] float radioKick;
    [SerializeField] float distance;
    [SerializeField] LayerMask layerMaskDetec;
    [SerializeField] Vector3 kickForce;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        anim.SetBool("Target", Target);
        anim.SetFloat("Distance", distance);
    }

    private void FixedUpdate()
    {
        CheckForTargetInRange();
    }

    private void CheckForTargetInRange()
    {
        Collide = Physics.OverlapCapsule(pivotCapsule1.position, pivotCapsule2.position, radio, layerMaskDetec);
        if (Collide.Length != 0)
        {
            Target = true;
            distance = Vector3.Distance(transform.position, Collide[0].transform.position);
        }
        else { Target = false; }
    }

    public void Pushs()
    {
        collideKick = Physics.OverlapSphere(pivotKick.position,radioKick,layerMaskDetec);
        
        if(collideKick.Length != 0)
        {
            Vector3 direction = collideKick[0].transform.position - transform.position;
            Vector3 force = new Vector3(direction.x * kickForce.x, kickForce.y, 0);
            collideKick[0].GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pivotCapsule1.position, radio);
        Gizmos.DrawWireSphere(pivotCapsule2.position, radio);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pivotKick.position, radioKick);

    }
}
