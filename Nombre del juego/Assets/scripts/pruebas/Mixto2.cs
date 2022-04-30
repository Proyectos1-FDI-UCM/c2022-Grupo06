using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixto2 : Mixto
{
    private RandomManager2 _random2;
    private void Start()
    {
        _random2 = GameObject.Find("RandomManager").GetComponent<RandomManager2>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow2>())
        {
            _random2.Cambio(true);
        }
    }
}
