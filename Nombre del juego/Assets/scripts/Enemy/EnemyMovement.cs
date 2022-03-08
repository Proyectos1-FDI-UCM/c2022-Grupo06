using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    #region parametros
    [SerializeField]
    private float _speed = 0.5f;

    private Transform _mytransform;

    private float _movFactor =1;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _mytransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right.normalized*_movFactor* _speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _movFactor *= -1;
        //if(_movFactor ==1) _mytransform.eulerAngles = new Vector2(0, 0);
        //else _mytransform.eulerAngles = new Vector2(0, 180);
    }
}
