using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuVolume : MonoBehaviour
{
    public Slider sliderMusique;
    public Slider sliderAmbiance;
    public Slider sliderDialogue;
    public AudioMixer audioMixer;

    void Start()
    {
        sliderMusique.onValueChanged.AddListener(sliderMusique_onValueChanged);
        sliderAmbiance.onValueChanged.AddListener(sliderAmbiance_onValueChanged);
        sliderDialogue.onValueChanged.AddListener(sliderDialogue_onValueChanged);
    }

    

    void sliderMusique_onValueChanged(float value)
    {
        audioMixer.SetFloat("GainMusique",Mathf.Log(value )* 20f);
    }
    void sliderDialogue_onValueChanged(float value)
    {
        audioMixer.SetFloat("GainDialogue", Mathf.Log(value) * 20f);
    }
    void sliderAmbiance_onValueChanged(float value)
    {
        audioMixer.SetFloat("GainAmbiance", Mathf.Log(value) * 20f);
    }
}
