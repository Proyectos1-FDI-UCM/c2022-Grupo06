using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguientePrueba2 : LucesPruebasDetection
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow2>())
        {
            _luz.SetActive(true);
        }
    }
}
