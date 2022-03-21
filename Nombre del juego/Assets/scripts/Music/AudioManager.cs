using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public Sounds[] sounds;
    // Start is called before the first frame update
    
    void Awake()
    {
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
