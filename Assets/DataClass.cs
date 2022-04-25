using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

[System.Serializable]
public class DataClass
{
    // get the data of the player and stores it in this class
    public int level;
    public int health;
    public float[] position;

    public DataClass(Player player)
    {
        if (player != null)
        {
            level = player.level;
            health = player.health;

            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
        }
    }
}
