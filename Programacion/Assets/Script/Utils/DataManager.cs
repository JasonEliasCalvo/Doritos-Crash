using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] GameInfo gameInfo;
    string nameFile;
    public void Awake()
    {
        nameFile = Application.persistentDataPath + "/DatosJuego";
    }

    void Start()
    {
        //SaveData();
        gameInfo = LoadData();
    }

    public void SaveData()
    {
        // Convierte un valor en un string con formato json
        string json = JsonUtility.ToJson(gameInfo);

        Debug.Log(nameFile);
        //Crea un archivo de texto en la ubicacion prederterminada segun el dispositivo

        if (!File.Exists(nameFile))
        {
            File.CreateText(nameFile).Close();
        }

        File.WriteAllText(nameFile, json);
    }

    public GameInfo LoadData()
    {
        string json = File.ReadAllText(nameFile);
        return JsonUtility.FromJson<GameInfo>(json);
    }
}
