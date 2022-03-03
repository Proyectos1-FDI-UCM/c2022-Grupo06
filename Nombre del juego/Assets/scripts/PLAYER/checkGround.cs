using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    static public checkGround Gcheck;

    public bool isGrounded;
    void Start()
    {
        Gcheck = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    public bool Suelo(bool ground)
    {
        ground = isGrounded;
        return ground;
    }
}
