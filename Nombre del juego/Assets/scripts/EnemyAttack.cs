using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Vector2 dir;
    [SerializeField]
    private Transform _playerPosition;
    private Transform _myTransform;
    private GameObject newBullet;
    [SerializeField]
    private float _offset = 0.4f;
    
    private Vector3 _aimingUp= new Vector3 (0,1,0);
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private GameObject _origin;
    private bool _firstShoot=false;
    private bool _canShoot = true;
    private LayerMask _playerLayer;

    private float _atCD=1;
    private void ShotAble()
    {
        if (Physics2D.Raycast(_myTransform.position, (_playerPosition.position - _myTransform.position), 1000.0f, _playerLayer))
        {

            _canShoot = false;
        }
        else _canShoot = true;
        Debug.Log(_canShoot);
    }
    private void Shoot( in Vector2 dir, float force)
    {
        if(dir.magnitude <= 10.0f)
        {
            newBullet = Instantiate(_bullet, _origin.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = force * dir.normalized;
            Debug.Log(dir);
            _firstShoot = true;
        }
    }
    void Start()
    {
        _playerLayer = 1 << 8;
        _myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ShotAble();
       
        _atCD = _atCD + Time.deltaTime;
        dir = _playerPosition.position+ - _myTransform.position+_aimingUp*_offset;              // pongo un offset para que apunte un poco más arriba, para predecir el movimiento del personaje
        if(_atCD>0 && _firstShoot == false &&_canShoot==true)
        {
            Shoot(dir, 10.0f);
            _firstShoot = true;
        }
        else if (_atCD >= 5 && _firstShoot==true && _canShoot==true)
        {          
            Shoot(dir, 10.0f);
            _atCD = 0;
        }       
    }
}
