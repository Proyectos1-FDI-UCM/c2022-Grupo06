using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixto : MonoBehaviour
{
    private RandomManager2 _random;
    [SerializeField]
    private GameObject _destroy;
    private void Start()
    {
        _random = GameObject.Find("RandomManager").GetComponent<RandomManager2>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput_Component>())
        {
            _random.Cambio(true);
            _destroy.SetActive(false);
            
        }
    }
 
}
