using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotPointDetector : MonoBehaviour
{
    //script que activa o desactiva el arco en funcion de si puede o no disparra
  
    static public bool canShootArrow;
    private bool toggle = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision!!");
        toggle = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("collision!!");
        toggle = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("exit!!");
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!toggle)
        {
            canShootArrow = true;
        }
        else if (toggle)
        {
            canShootArrow = false;
        }
    }
}
