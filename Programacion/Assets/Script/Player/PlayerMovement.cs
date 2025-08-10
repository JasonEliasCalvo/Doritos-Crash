using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    BaseState currentState;

    public IdleState _idle;
    public WalkState _walk;
    public RunState _run;
    public CrouchState _crouch;
    public SlideState _slide;
    public JumpState _jump;
    public FallState _fall;

    public Animator anim;
    public Rigidbody rigid;
    public float horizontal;

    public KeyCode crouchKey = KeyCode.LeftShift;
    public KeyCode runKey = KeyCode.LeftControl;
    public KeyCode jumpKey = KeyCode.Space;

    public float speedMovement;
    public float jumpForce;
    [SerializeField]
    private bool facingRight;
    private float rotationY;
    [SerializeField]
    private float speedRotation;
    public bool isGrounded;

    [SerializeField]
    LayerMask layer;
    [SerializeField]
    private Transform pivotOrigin;
    [SerializeField]
    private Vector3 detectecZone;

    bool movementState;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

        _idle = new IdleState(this);
        _walk = new WalkState(this);
        _run = new RunState(this);
        _crouch = new CrouchState(this);
        _slide = new SlideState(this);
        _jump = new JumpState(this);
        _fall = new FallState(this);
        ChangeState(_idle);

        facingRight = false;
        rotationY = transform.rotation.y;

        GameManager.instance.eventGameStart += ActiveMovement;
        GameManager.instance.eventGameEnd += DeactivateMovement;
    }

    void Update()
    {
        AnimationsParemeter();
        if (movementState)
        {
            currentState.UpdateState();
            Inputs();
            Flip();  
        }       
    }

    private void Inputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(crouchKey)) anim.SetBool("Crouch", true);
        if (Input.GetKeyUp(crouchKey)) anim.SetBool("Crouch", false);
    }

    private void FixedUpdate()
    {
        if (movementState)
        {
            currentState.FixedUpdateState();
        }
           
        DetectedGround();
    }

    private void DetectedGround()
    {
        Collider[] collide = Physics.OverlapBox(pivotOrigin.position, detectecZone, pivotOrigin.rotation, layer);
        isGrounded = collide.Length > 0 ? true : false;
    }

    public void ChangeState(BaseState nextState)
    {      
        currentState = nextState;
        currentState.EnterState();
    }

    private void Flip()
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) 
            facingRight = !facingRight;

        rotationY = facingRight ? 90 : -90;

        if (transform.eulerAngles.y != rotationY)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, rotationY, transform.eulerAngles.z), speedRotation * Time.deltaTime);
    }

    private void AnimationsParemeter()
    {
        anim.SetFloat("Vertical", rigid.linearVelocity.y);
        anim.SetFloat("Horizontal", horizontal);
        anim.SetBool("IsGrounded", isGrounded);
    }

    public void ActiveMovement()
    {
        movementState = true;
    }
    public void DeactivateMovement()
    {
        movementState = false;
        horizontal = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(pivotOrigin.position, detectecZone); ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            transform.position = CheckPointController.instance.GetLastCheckPoint().transform.position;
        }
    }

    public void CrossAnimation()
    {
        anim.Play("Idle",0,anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
