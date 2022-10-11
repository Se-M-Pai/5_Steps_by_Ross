using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSrc;
    public float soundVolume;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void Update()
    {
        soundVolume = PlayerPrefs.GetFloat("SoundLevel");
        audioSrc.volume = soundVolume;
    }

    public void SetVolume(float vol)
    {
        soundVolume = vol;
        PlayerPrefs.SetFloat("SoundLevel", soundVolume);
        PlayerPrefs.Save();
    }
}
