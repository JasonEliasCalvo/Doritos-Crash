using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    private void Start()
    {
        //Breathe();
        //Eat();
        //Roar();
    }

    void Roar()
    {
        Debug.Log(name + " esta ladrando");
    }
}
