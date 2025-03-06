using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : Animal
{
    void Start()
    {
        //Breathe();
        //Eat();
        //Fly();
    }

    void Fly()
    {
        Debug.Log(name + " esta Volando");
    }

    public override void Attack()
    {
        Debug.Log(name + " esta dando picotazos");
        base.Attack();
    }
}
