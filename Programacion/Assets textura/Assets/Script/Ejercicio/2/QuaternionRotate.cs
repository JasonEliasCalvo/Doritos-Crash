using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotate : MonoBehaviour
{
    [SerializeField]
    Transform[] targetRotation;
    [SerializeField]
    int currentRotation;
    [SerializeField]
    float speedRotation;

    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation[currentRotation].rotation, speedRotation * Time.deltaTime);

        if (transform.position == targetRotation[currentRotation].position)
        {
            if (targetRotation.Length - 1 == currentRotation)
            {
                currentRotation = 0;
            }
            else
                currentRotation += 1;
        }
    }
}
