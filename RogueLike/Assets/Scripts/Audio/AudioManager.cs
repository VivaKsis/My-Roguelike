using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    public static void PlaySoundOnGameObject(GameObject gameObject, AudioClip audioClip)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
    }
}
