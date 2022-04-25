using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System;

namespace Utility
{
    public static class SaveSystem
    {
        private static string path = Environment.CurrentDirectory + "/player.json";

        public static void SavePlayerToJson(Player player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create); // create the file on the path weve made

            DataClass data = new DataClass(player); // creating the data class and setting it up

            formatter.Serialize(stream, data); //write the data to the file
            stream.Close();
        } // save to json


        public static DataClass LoadDataFromJson()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                DataClass data = (DataClass)formatter.Deserialize(stream);
                stream.Close();

                return data;
            }
            catch (System.Exception)
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        } // load from json

        public static void SavePlayerToPrefs(Player player)
        {
            try
            {
                DataClass data = new DataClass(player);
                PlayerPrefs.SetInt("SaveInteger", 0);

                PlayerPrefs.SetInt("PlayerHealth", data.health);
                PlayerPrefs.SetInt("PlayerLevel", data.level);

                PlayerPrefs.SetFloat("PosX", data.position[0]);
                PlayerPrefs.SetFloat("PosY", data.position[1]);
                PlayerPrefs.SetFloat("PosZ", data.position[2]);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to save PlayerPrefs [stacktrace massage]: {ex.Message}");
            }
           

        } // the actual mission, save to PlayerPrefs

        public static void LoadPlayerPrefs(Player player)
        {
            try
            {
                Vector3 position;
                player.health = PlayerPrefs.GetInt("PlayerHealth");
                player.level = PlayerPrefs.GetInt("PlayerLevel");
                position.x = PlayerPrefs.GetFloat("PosX");
                position.y = PlayerPrefs.GetInt("PosY");
                position.z = PlayerPrefs.GetInt("PosZ");
                player.transform.position = position;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to load PlayerPrefs [stacktrace massage]: {ex.Message}");
            }
           

        } // the actual mission, load from PlayerPrefs
    }
}
