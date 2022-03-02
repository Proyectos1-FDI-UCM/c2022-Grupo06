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
    private GameObject _bullet;
    [SerializeField]
    private GameObject _origin;
    private bool _firstShoot=false; 

    private float _atCD=1;

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
        _myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _atCD = _atCD + Time.deltaTime;
        dir = _playerPosition.position - _myTransform.position;
        if(_atCD>0 && _firstShoot == false)
        {
            Shoot(dir, 10.0f);
            _firstShoot = true;
        }
        else if (_atCD >= 5 && _firstShoot==true)
        {          
            Shoot(dir, 10.0f);
            _atCD = 0;
        }
        
    }
}
