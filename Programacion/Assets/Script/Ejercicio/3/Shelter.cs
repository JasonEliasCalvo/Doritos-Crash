using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{
    [SerializeField] List<Animal> animals;

    private void Start()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            animals[i].Attack();
        }
    }
}
