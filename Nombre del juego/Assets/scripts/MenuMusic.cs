using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField]
    public GameObject _menu;
    AudioSource _audiosource;
    bool _mute;
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _mute = GetComponent<AudioSource>().mute;
        
    }

    public void Sound(bool enabled)
    {
        if (enabled)
        {
            _audiosource.Play();
        }

    }
    public void mute(bool enabled)
    {
        _mute = enabled;

    }
}
