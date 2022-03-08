using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    #region parametros
    [SerializeField]
    private float _speed = 0.5f;

    private Transform _mytransform;
    private float _direccion = 1;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _mytransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right.normalized* _direccion* _speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _direccion *= -1;
        if (_direccion > 0)
        {
            _mytransform.eulerAngles = new Vector3(0, 0, 0);

        }
        else
        {
            _mytransform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
