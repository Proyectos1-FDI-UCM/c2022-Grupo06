using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    //Declaramos todas nuestras variables
    #region parameters
    private Transform _myTransform;   //el transform de la c�mara
    [SerializeField]
    public float _vel;              //una velocidad que solo utilizaremos para parar el movimiento de la c�mara
    public float _accel;           //aceleraci�n que incrementar� con el tiempo
    [SerializeField]
    private float _coefaccel;       //coeficiente del que depende el valor de la aceleraci�n
    private float _elapsedTime;     //tiempo que ha pasado, para la aceleraci�n
    [SerializeField]
    private float _world_limit = 10.0f;
    [SerializeField]
    private float _startingtime =3.0f;
    #endregion

    AudioSource _audioSource;
    [SerializeField]
    GameObject _camera;
    void Start()
    {
        _myTransform = GetComponent<Transform>();      //cacheamos el transform
        _audioSource = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        
        _elapsedTime += Time.deltaTime;           //_elapsedTime= _elapsedTime + Time.deltaTime;

        if (_elapsedTime >= _startingtime)                          //empezar� acelerar cuando pase X tiempo
        {
            _accel = _vel +(_elapsedTime *_coefaccel);                      
            _myTransform.position = _myTransform.position + _accel * Vector3.up;      
        }
        else _myTransform.position = _myTransform.position + _vel* Vector3.up;    //nuestra posici�n ser� incremental con respecto al eje Y

        if (_myTransform.position.y >= _world_limit)                   //cuando llegue a una cota del eje Y se para
        {
            _vel = 0;
            _accel = 0;
        }

    }
    public void Audio(bool enabled)
    {
        if (enabled)
        {
            _audioSource.Play();
        }
        
    }

}
