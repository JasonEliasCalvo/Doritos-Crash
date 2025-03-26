using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelInfo
{
    [SerializeField] bool _completed;
    [SerializeField] int _bestScore;

    public int BtS { get => _bestScore; set => _bestScore = value; }
    public bool Cptd { get => _completed; set => _completed = value; }
}
