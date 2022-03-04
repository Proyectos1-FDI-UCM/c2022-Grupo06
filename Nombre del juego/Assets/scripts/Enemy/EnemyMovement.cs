using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    #region parametros
    [SerializeField]
    private float _speed = 0.01f;
    [SerializeField]
    private float _posderecha = 3;
    [SerializeField]
    private float _posizquierda = 1;
    bool derecha = true;
    bool izquierda = false;
    private Transform _mytransform;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _mytransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(_mytransform.position.x <= _posderecha && derecha)
        {
            transform.Translate(Vector2.right * _speed);
            if (_mytransform.position.x > _posderecha)
            {
                derecha = false;
                izquierda = true;
                
            }
        }
        else if (_mytransform.position.x >= _posizquierda && izquierda)
        {
            transform.Translate(Vector2.left * _speed);
            if (_mytransform.position.x < _posizquierda)
            {
                izquierda = false;
                derecha = true;
                
            }
        }

        



    }
}
