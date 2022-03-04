using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    static public checkGround Gcheck;
    public GameObject player;
    public bool isGrounded;
    int _layer = 8;
    void Start()
    {
        Gcheck = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        if (collision.gameObject.layer == _layer)
        {
            player.transform.parent = collision.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        player.transform.parent = null;
    }
    public bool Suelo(bool ground)
    {
        ground = isGrounded;
        return ground;
    }
}
