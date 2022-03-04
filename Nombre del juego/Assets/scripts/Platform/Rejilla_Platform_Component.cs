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
    private bool _fisrtime = true;
    private Player_Life_Component _player;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _myCollider = GetComponent<Collider2D>();
        _myCollider.isTrigger = true;

    }
    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Player_Life_Component>() && _fisrtime)
        {
            _myRigidbody.simulated = false;
            _playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            _playerRigidbody.velocity = new Vector2(0, _impulse);
            _fisrtime = false;
        }

    }
   void OnTriggerExit2D(Collider2D Collision)
    {
 
        
        if (Collision.gameObject.GetComponent<Player_Life_Component>())
        {
            _myRigidbody.simulated = true;
            _myCollider.isTrigger = false;
        }
    }
   

}
