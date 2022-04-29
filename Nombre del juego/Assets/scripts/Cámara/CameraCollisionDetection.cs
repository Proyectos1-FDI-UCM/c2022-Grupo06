using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;
    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.GetComponent<PlayerMovement>())
        {
            GameManager.Instance.PlayerDies();
            collision.gameObject.SetActive(false);
        }
        if (collision.GetComponent<Arrow>())
        {
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<GeneratorComponent>())
        {
            Destroy(collision.GetComponent<GeneratorComponent>().Zona);
            
        }
    }
}
