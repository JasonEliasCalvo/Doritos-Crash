using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected new string name;
    [SerializeField] protected int age;
    [SerializeField] protected float size;

    protected void Breathe()
    {
        Debug.Log(name + " esta respirando");
    }

    protected void Eat()
    {
        Debug.Log(name + " esta comiendo");
    }

    public virtual void Attack()
    {
        Debug.Log(name + " esta mordiendo");
    }
}
