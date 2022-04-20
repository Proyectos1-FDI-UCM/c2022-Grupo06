using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {      
       if (collision.GetComponent<PlayerMovement>())
       {
            //GameManager.Instance.PlayerDies();
            //collision.gameObject.SetActive(false);
       }
       if (collision.GetComponent<Arrow>())
       {
            Destroy(collision.gameObject);
       }
        if (collision.GetComponent<GeneratorComponent>())
        {
            Debug.Log("Zona destroy");
            Destroy(collision.GetComponent<GeneratorComponent>().Zona);
            
        }
    }
}
