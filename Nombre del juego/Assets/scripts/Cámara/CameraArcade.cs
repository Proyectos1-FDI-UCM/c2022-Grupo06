using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArcade : MonoBehaviour
{
    //Declaramos todas nuestras variables
    #region parameters
    private Transform _myTransform;   //el transform de la c�mara
    [SerializeField]
    public float _vel;              //una velocidad que solo utilizaremos para parar el movimiento de la c�mara�
    public float _velInicial;
    public float _accel;           //aceleraci�n que incrementar� con el tiempo
    [SerializeField]
    private float _coefaccel;       //coeficiente del que depende el valor de la aceleraci�n
    private float _elapsedTime;     //tiempo que ha pasado, para la aceleraci�n
    [SerializeField]
    private GameObject _initPoint;
    #endregion

    void Start()
    {
        _myTransform = transform;      //cacheamos el transform
        _velInicial = _vel;
        _myTransform.position = _initPoint.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        _myTransform.position = _myTransform.position + _vel * Vector3.up;    //nuestra posici�n ser� incremental con respecto al eje Y
    }
}
