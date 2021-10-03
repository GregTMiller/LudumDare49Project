using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SettingsData
{
    public bool fullscreenState;
    public int QuadSetting;
    public AudioMixer mainMixer;
    public AudioMixer sfxMixer;
    public AudioMixer musicMixer;

    private void Start() {
    }
    public SettingsData (SettingsMenu settings)
    {

        fullscreenState = settings.isCurrentlyFullscreen;

    }
    public void SetQuaulity(int QuadInt)
    {

        QualitySettings.SetQualityLevel(QuadInt, true);
        QuadSetting = QuadInt;

    }

    public void SetVolumeMain(float voulme)
    {

        mainMixer.SetFloat("volume", voulme);

    }
    public void SetVolumeSFX(float voulme)
    {

        sfxMixer.SetFloat("volume", voulme);

    }
       public void SetVolumeMusic(float voulme)
    {

        musicMixer.SetFloat("volume", voulme);

    }
}