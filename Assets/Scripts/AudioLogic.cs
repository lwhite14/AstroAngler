using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLogic : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    private float currentVolumeBack;
    public void StopBackgroundMusic()
    {
        float value = 0;
        audioMixer.GetFloat("BackgroundVolume",out value);
        currentVolumeBack = value;
        audioMixer.SetFloat("BackgroundVolume", -80f);
    }

    public void StopMiniGameMusic()
    {
        audioMixer.SetFloat("MiniGameVol", 0f);
    }

    public void StartBackgroundMusic()
    {
        audioMixer.SetFloat("BackgroundVolume", currentVolumeBack);
    }
}
