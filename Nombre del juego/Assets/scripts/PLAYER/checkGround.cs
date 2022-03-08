using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public GameObject player;
    int _layer = 8;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.GetComponent<Cloud>()) player.transform.parent = collision.gameObject.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.transform.parent = null;
    }
}
