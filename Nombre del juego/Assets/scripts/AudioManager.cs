using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField]
    public GameObject _menupausa;

    AudioSource _audioSource;

    #region instance
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
        _instance = this;
    }
    #endregion

    void Start()
    {
         _audioSource = GetComponent<AudioSource>();
  
    }
    public void Menu(bool enabled)
    {
        if (enabled)
        {
            _audioSource.Play();
            
        }
       
    }
    
   
}
