using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider SoundSettingSlider;
    public AudioMixer MasterMixer;
    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    public void SetVolume(float value)
    {
        if (value < 1)
        {
            value = 0.001f;
        }
        RefreshSlider(value);
        PlayerPrefs.SetFloat("SavedMasterVolume", value);
        MasterMixer.SetFloat("MasterVolume", Mathf.Log10(value / 100) * 20f);
    }
    public void SetVolumeFromSlider()
    {
        SetVolume(SoundSettingSlider.value);
    }
    public void RefreshSlider(float value)
    {
        SoundSettingSlider.value = value;
    }
}
