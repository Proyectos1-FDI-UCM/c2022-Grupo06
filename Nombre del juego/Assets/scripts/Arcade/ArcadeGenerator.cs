using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGenerator : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField]
    private Transform generador;
    int random;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<GeneratorComponent>())
    //    {
    //        Debug.Log("Generando nueva zona...");
    //        Instantiate(_lvlZones[Random.Range(0, 5)], new Vector3(0, transform.position.y, 0), Quaternion.identity);
    //    }
    //}
    private void Start()
    {
        _myTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (transform.position.y> generador.position.y)
        {
          
            GeneratorComponent.Instance.CambioPos();
        }
    }

}
