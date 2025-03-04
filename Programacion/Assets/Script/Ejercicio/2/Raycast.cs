using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private bool find;
    RaycastHit hit;
    [SerializeField]
    float distance;
    [SerializeField]
    LayerMask layer;
    [SerializeField]
    Vector3 scale;

    private void FixedUpdate()
    {
        find = Physics.Raycast(transform.position, Vector3.forward, out hit, distance, layer);

        if (find)
        {
            if(hit.collider.transform.localScale != scale)
                hit.collider.transform.localScale = hit.collider.transform.localScale + (Vector3.one * 0.01f);
            else
                Destroy(hit.collider.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.forward * distance);
    }
}
