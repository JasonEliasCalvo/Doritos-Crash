using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerInfo
{
    [SerializeField] string _name;
    [SerializeField] int _coins;
    [SerializeField] int _live;

    public string Name { get => _name; set => _name = value; }
    public int Coins { get => _coins; set => _coins = value; }
    public int Live { get => _live; set => _live = value; }
}
