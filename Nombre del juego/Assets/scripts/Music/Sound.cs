using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string _nombre;
    public AudioClip _clip;


    
    public float _volume;
    public float _pitch;
    public bool _mute;
    public bool _loop;

    [HideInInspector]  //no te hace falta que aparezca en el inspector, se va a llamar directamente desde el awake del AudioManageer
    public AudioSource _audiosource;
 
}
