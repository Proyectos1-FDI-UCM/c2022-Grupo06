using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectileRotation : MonoBehaviour
{
    [SerializeField]
    private Transform _rotateAround;
    private Transform _mytransform;
    private Rigidbody2D _myRigid;
    private GameObject _myself;
    Vector2 dir;

    void Start()
    {
        _myRigid = GetComponent<Rigidbody2D>();
        _mytransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Vector2 fuerza = this.GetComponent<Rigidbody2D>().velocity = 10.0f * Vector2.right;
        //dir = (_rotateAround.position - _mytransform.position)* fuerza;
        
        _mytransform.Rotate(_rotateAround.position,10.0f);
    }
}
