using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScreenController : MonoBehaviour
{
    private bool isFullScreen = false;

    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedSettings.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavedSettings.dat", FileMode.Open);
            SavedSettings data = (SavedSettings)bf.Deserialize(file);
            file.Close();
            Screen.fullScreen = data.fullScreen;
        }
        else
            Debug.Log("There is no saved data!");
    }
}
