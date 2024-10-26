﻿using UnityEngine;
using UnityEngine.Audio;

public class MixerManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    private void Awake()
    {
        UIManager.Instance.OnMasterSlider += MasterVolumeSlider;
        UIManager.Instance.OnMusicSlider += MusicVolumeSlider;
        UIManager.Instance.OnSFXSlider += SFXVolumeSlider;
        UIManager.Instance.OnSoundToggle += ToggleSound;
    }

    void MasterVolumeSlider(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20f);
    }
     void MusicVolumeSlider(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20f);

    }
     void SFXVolumeSlider(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20f);
    }

    void ToggleSound(bool b)
    {
        Camera.main.gameObject.GetComponent<AudioListener>().enabled = b;
    }

}