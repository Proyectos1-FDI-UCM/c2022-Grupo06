using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image mute;



    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f); //al iniciar valor predefinido 0.5
        AudioListener.volume = slider.value;//el volumen de nuestro juego es igual al volumen del slider
        CompruebaMute();
    }

    public void ChangeVolume(float number)
    {
        sliderValue = number;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        CompruebaMute();
    }


    public void CompruebaMute()
    {
        if (sliderValue == 0)
        {
            mute.enabled = true;
        }
        else
        {
            mute.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
