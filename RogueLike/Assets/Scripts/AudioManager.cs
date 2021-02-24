using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    //TODO Pool
    public static void PlaySound(AudioClip audioClip)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
    }
}
