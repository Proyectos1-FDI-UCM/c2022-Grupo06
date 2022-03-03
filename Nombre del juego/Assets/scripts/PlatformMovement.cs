using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Transform _myTransform;
    [SerializeField]
    private Transform _pos1;
    [SerializeField]
    private Transform _pos2;
    [SerializeField]
    private Transform _posInicial;
    Vector3 nexPos;
    // Start is called before the first frame update
    void Start()
    {
        nexPos = _posInicial.position;
        _myTransform = GetComponent<Transform>();
        _myTransform.position = _pos1.position;
    }
    void Update()
    {
        if (_myTransform.position == _pos1.position) //si la posición es el primer punto, cambiara el destino al segundo
        {
            nexPos = _pos2.position;
        }
        else if (_myTransform.position == _pos2.position)//si la posición es el segundo punto, cambiara el destino al primero
        {
            nexPos = _pos1.position;
        }
        _myTransform.position = Vector3.MoveTowards(_myTransform.position, nexPos ,speed*Time.deltaTime); //donde esta, a donde va y con que velocidad

    }
    private void OnDrawGizmos() //para poder ver el recorrido que va a hacer la plataforma
    {
        Gizmos.DrawLine(_pos1.position, _pos2.position);
    }
}
