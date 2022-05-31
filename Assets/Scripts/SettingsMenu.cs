using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class SavedSettings
{
    public float Volume;
    public float MiniGameVolume;
    public bool fullScreen;
    public int resolutionIndex;
}

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Slider volumeSlider;
    public Slider miniGameVolumeSlider;

    private float currentVolume;
    private float currentMiniGameVolume;
    private int currentResolutionIndex;
    private Resolution[] resolutions;
    private bool FullScreen = false;

    public void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int resolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(resolutionIndex);
        //Debug.Log(currentResolutionIndex);
    }

    public void SetVolume(float sliderValue)
    {
        // Testing purposes
        // Debug.Log("Volumes has changed" + sliderValue);
        audioMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        audioMixer.SetFloat("BackgroundVolume", Mathf.Log10(sliderValue) * 20);
        currentVolume = sliderValue;
    }

    public void SetMiniGameVolume(float sliderValue)
    {
        audioMixer.SetFloat("MiniGameVol", Mathf.Log10(sliderValue) * 20);
        currentMiniGameVolume = sliderValue;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        FullScreen = isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        currentResolutionIndex = resolutionIndex;
        Debug.Log(currentResolutionIndex);
    }

    public void SaveSettings()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SavedSettings.dat");
        SavedSettings data = new SavedSettings();
        data.Volume = currentVolume;
        data.fullScreen = FullScreen;
        Debug.Log("ResolutionIndex in SaveSettings" + currentResolutionIndex);
        data.resolutionIndex = currentResolutionIndex;
        data.MiniGameVolume = currentMiniGameVolume;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Settings has saved in " + file.Name);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (File.Exists(Application.persistentDataPath + "/SavedSettings.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavedSettings.dat", FileMode.Open);
            SavedSettings data = (SavedSettings)bf.Deserialize(file);
            file.Close();
            // SetVolume(data.Volume);
            volumeSlider.value = data.Volume;
            miniGameVolumeSlider.value = data.MiniGameVolume;
            // SetResolution(currentResolutionIndex);
            //resolutionDropdown.value = data.resolutionIndex;
            // SetFullScreen(data.fullScreen);
            Screen.fullScreen = data.fullScreen;
            Debug.Log("Game data is loaded!" + "fullScreen" + data.fullScreen + "volume" + data.Volume + "ri" + currentResolutionIndex);
        }
        else
            Debug.Log("There is no saved data!");
    }
}
