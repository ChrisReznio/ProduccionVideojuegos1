using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public Slider slider;

    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volume");
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }
}
