using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestruction : MonoBehaviour
{
    [SerializeField]
    private int _vidasMax;  
    [SerializeField]
    public GameObject[] objetos = new GameObject [9];

    private int _vidasActuales;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow2>())
        {

            Destroy(objetos[Random.Range(0, 9)]);               //imagina que sale dos veces 7, eliminamos algo ya eliminado-------> solucionar
            Debug.Log("entra");
            _vidasActuales= _vidasActuales- 1;
        }
    }

     void Start()
     {
        _vidasActuales = _vidasMax;
     }
    private void Update()
    {
        Debug.Log(_vidasActuales);
        if (_vidasActuales == 0)
        {
            Destroy(gameObject);
        }
    }
}
