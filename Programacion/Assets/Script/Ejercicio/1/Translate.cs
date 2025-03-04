using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
            transform.Translate(new Vector3(0, -speed, 0), Space.World);
        else
            transform.Translate(new Vector3(0, speed, 0), Space.World);
    }
}
