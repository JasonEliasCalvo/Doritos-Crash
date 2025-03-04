using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Move : MonoBehaviour
{
    [SerializeField]
    Transform[] targetPosition;
    [SerializeField]
    int currentPosition;
    [SerializeField]
    float speedPosition;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition[currentPosition].position, speedPosition * Time.deltaTime);

        if(transform.position == targetPosition[currentPosition].position)
        {
            if(targetPosition.Length - 1 == currentPosition)
            {
                currentPosition = 0;
            }
            else
                currentPosition += 1;
        }
    }
}
