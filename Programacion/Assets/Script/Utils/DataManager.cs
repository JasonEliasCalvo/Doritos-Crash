using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] 
    GameInfo gameInfo;

    [SerializeField]
    WorldInfo worldInfo;

    void Start()
    {
        if(PlayerPrefs.HasKey("Volume"))
        {
            Debug.Log(PlayerPrefs.GetFloat("Volume"));
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 100f);
            Debug.Log("Valor guardado");
        }
    }
}
