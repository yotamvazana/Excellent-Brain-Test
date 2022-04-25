using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Player : MonoBehaviour
{
    public int level;
    public int health;

    public void SavePlayer()
    {
        SaveSystem.SavePlayerToJson(this);
    } // this saves to json

    public void LoadPlayer()
    {
        DataClass data = SaveSystem.LoadDataFromJson();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        level = data.level;
        health = data.health;

    }// this load from json

    public void SaveToPlayerPrefs()
    {
        SaveSystem.SavePlayerToPrefs(this);
    } // save to playerprefs

    public void LoadPlayerFromPrefs() // load from playerprefs
    {
        SaveSystem.LoadPlayerPrefs(this);
    }

    #region UI
    public void ChangePlayerLevel(int amount)
    {
        level += amount;
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
    }

    public void AddOrRemoveHealth(int amount)
    {
        health += amount;
    }

    public void AddOrRemoveLevel(int amount)
    {
        level += amount;
    }


    #endregion


}
