using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public Sounds[] sounds;

    static private AudioManager _instance;
    static public AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    void Awake()
    {
        _instance = this;
        foreach(Sounds sound in sounds)
        {
            sound._audiosource = gameObject.AddComponent<AudioSource>();
            sound._audiosource.clip = sound._clip;
            sound._audiosource.volume = sound._volume;
            sound._audiosource.pitch = sound._pitch;
        }
        
    }

    public void Play(string soundname)
    {
        Sounds audio = Array.Find(sounds, sound => sound._nombre == soundname);
        audio._audiosource.Play();

    }
}
