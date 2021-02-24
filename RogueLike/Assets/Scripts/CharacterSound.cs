using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    public AudioClip _AudioClip => _audioClip;
}
