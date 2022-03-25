using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlatformMovement>()) transform.parent = collision.gameObject.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Player_Life_Component.instance.isAlive == true) transform.parent = null;
    }
}
