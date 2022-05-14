using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGenerator : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField]
    private Transform generador;
    
    private void Start()
    {
        _myTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (_myTransform.position.y> generador.position.y)
        {
            GeneratorComponent.Instance.CambioPos();
        }
    }

}
