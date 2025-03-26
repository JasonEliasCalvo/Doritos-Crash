using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameInfo
{
    [SerializeField] List<PlayerInfo> _players = new List<PlayerInfo>();
    [SerializeField] List<WorldInfo> _Worlds = new List<WorldInfo>();

    public List<PlayerInfo> Players { get => _players; set => _players = value; }
    public List<WorldInfo> Worlds { get => _Worlds; set => _Worlds = value; }
}
