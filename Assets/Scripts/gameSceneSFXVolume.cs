using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class gameSceneSFXVolume : MonoBehaviour
{

    public AudioSource audioSource;

    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    
}
