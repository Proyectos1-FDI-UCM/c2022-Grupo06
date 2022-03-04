using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyProyectileRotation : MonoBehaviour
{
    [SerializeField]
    private Transform _rotateAround;
    private Transform _mytransform;
    private float _elapsedTime=0;
    [SerializeField]
    private float _initialIntensity;
    [SerializeField]
    private float _lifeTime=5;
    private float _lightStart;
    private float _intenisityReduction;
    private Light2D _myLight;

    void Start()
    {
        _myLight = GetComponent<Light2D>();
        _mytransform = GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= 0.2f)
        {
            _elapsedTime = 0;
            _myLight.intensity=Mathf.Lerp(0f,_initialIntensity, _elapsedTime/100);
        }
        //Vector2 fuerza = this.GetComponent<Rigidbody2D>().velocity = 10.0f * Vector2.right;
        //dir = (_rotateAround.position - _mytransform.position)* fuerza;
        _mytransform.Rotate(_rotateAround.position,10.0f);
        if(_elapsedTime>= _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
