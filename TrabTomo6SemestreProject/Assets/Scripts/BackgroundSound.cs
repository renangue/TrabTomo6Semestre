using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public AudioClip music;
    public bool loop;
    public bool persistent;

    [Range(0, 1)] public float volume;

    void Start()
    {
        AudioManager.BGSVolume = 0.14f;

        AudioManager.SFXVolume = 0.5f;

        AudioManager.PlayBGS(music, loop, persistent);
        
    }
}
