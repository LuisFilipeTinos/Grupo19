using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int id { get; private set; }
    public string playerName { get; private set; }

    public Player(int id, string playerName)
    {
        this.id = id;
        this.playerName = playerName;
    }
}
