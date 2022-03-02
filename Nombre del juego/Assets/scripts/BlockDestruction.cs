using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestruction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow2>())
        {
            Destroy(gameObject);
        }
    }
}
