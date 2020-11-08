using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer2;
    public Slider slider;

    public void Start()
    {
     
        mixer2.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20 );

        if (this.gameObject.name == "MusicVolumeSlider") {
            slider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else if (this.gameObject.name == "SFXVolumeSlider")
        {
            slider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    private void Update()
    {
        if (this.gameObject.name == "MusicVolumeSlider")
        {
            PlayerPrefs.SetFloat("MusicVolume", slider.value);
        }
        else if (this.gameObject.name == "SFXVolumeSlider")
        {
            PlayerPrefs.SetFloat("SFXVolume", slider.value);

        }
    }

    public void SetLevel(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        //PlayerPrefs.SetFloat("MusicVolume", volume);
        mixer2.SetFloat("MusicVol", volume);
    }


}
