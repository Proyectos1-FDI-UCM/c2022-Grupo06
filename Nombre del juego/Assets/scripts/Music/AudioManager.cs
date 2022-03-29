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
    
    private void Awake()
    {
         if (_instance == null)
         {
             _instance = this;
         }
         else
         {
             Destroy(gameObject);
         }
         DontDestroyOnLoad(gameObject);
      
        foreach(Sounds sound in sounds)
        {
            sound._audiosource = gameObject.AddComponent<AudioSource>();
            sound._audiosource.clip = sound._clip;
            sound._audiosource.volume = sound._volume;
            sound._audiosource.pitch = sound._pitch;
            sound._audiosource.mute = sound._mute;
            sound._audiosource.loop = sound._loop;
        }
        
    }

    public void Play(string soundname)
    {
        Sounds audio = Array.Find(sounds, sound => sound._nombre == soundname);
        audio._audiosource.Play();
          
    }

    public void Stop (string soundname)
    {
        Sounds audio = Array.Find(sounds, sound => sound._nombre == soundname);
        audio._audiosource.Stop();

    }
    //public void Mute(string soundname)
    //{
    //    Sounds audio = Array.Find(sounds, sound => sound._nombre == soundname);
    //    audio._mute = true;
        

    //}
}
