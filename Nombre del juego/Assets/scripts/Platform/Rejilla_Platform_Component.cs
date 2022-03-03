using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rejilla_Platform_Component : MonoBehaviour
{
    #region parametros
    private Rigidbody2D _myRigidbody;
    private Rigidbody2D _playerRigidbody;
    private Collider2D _myCollider;
    private float _impulse = 35.0f;
    private float _timer = 0.0000020f;
    private float _currentimer = 0;
    private bool _fisrtime = true;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _myCollider = GetComponent<Collider2D>();
        _myCollider.isTrigger = true;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        Player_Life_Component _player = collision.gameObject.GetComponent<Player_Life_Component>();
        if (_player != null && _fisrtime)
        {

            _myRigidbody.simulated = false;
            _playerRigidbody = _player.GetComponent<Rigidbody2D>();
            _playerRigidbody.velocity = new Vector2(0, _impulse);
            _currentimer = _timer;
            _fisrtime = false;
        }

    }
   void OnTriggerExit2D(Collider2D Collision)
    {
        Debug.Log("exittttt");
        Player_Life_Component _player = Collision.gameObject.GetComponent<Player_Life_Component>();
        if (_player != null)
        {
            _myRigidbody.simulated = true;
            _myCollider.isTrigger = false;
        }
    }
    void Update()
    {
        if (_currentimer > 0)
        {
            Debug.Log("ein");
            Debug.Log(_currentimer);
            _currentimer -= Time.deltaTime;
        }
        else if (_currentimer < 00.00000010f)
        {
            Debug.Log("entra?");
            _myRigidbody.simulated = true;
            _currentimer = 0;
        }
    }

}
