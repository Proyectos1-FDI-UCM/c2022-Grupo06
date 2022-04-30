using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGenerator : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField]
    private Transform generador;
    int random;
    
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
