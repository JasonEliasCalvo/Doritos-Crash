using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;
    [SerializeField]
    private CheckPoint currentCheckPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void GetCheckPoint(CheckPoint newPoint)
    {
        currentCheckPoint = newPoint;
    }

    public CheckPoint GetLastCheckPoint()
    {
        return currentCheckPoint;
    }
}
