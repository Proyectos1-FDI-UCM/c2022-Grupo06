using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _cosas2 = new GameObject[15];
    private bool _activated;

    static private RandomManager2 _instance;
    static public RandomManager2 Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Start()
    {
        _activated = true;
    }
    public void Cambio(bool enabled)
    {
        _activated=enabled;
    }

    // Update is called once per frame
    void Update()
    {       
         int _random = Random.Range(0, 14);
        Debug.Log(_activated);
        if (_activated == true)
        {
            _cosas2[_random].SetActive(true);
            _activated = false;
        }
    }
}
