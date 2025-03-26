using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WorldInfo
{
    [SerializeField] List<LevelInfo> _levels = new List<LevelInfo>();
    [SerializeField] bool _completed;

    public List<LevelInfo> Lvls { get => _levels; set => _levels = value; }
    public bool Cptd { get => _completed; set => _completed = value; }
}
