using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Platform_Component : MonoBehaviour
{
    #region Parametres
    private Rigidbody2D _myRigidbody;
    [SerializeField]
    private float _timer = 3.0f;
    private float _currentime = 0;
    [SerializeField]
    private float _impulse = 4.0f;
    [SerializeField]
    private float _gravity = 3.0f;
    [SerializeField]
    private int _damage;

    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.GetComponent<Player_Life_Component>())
        {

            //Llamada al Game Manager correspondiente
            //collision.gameObject.GetComponent<Player_Life_Component>().gameObject.SetActive(false);// por ahora se queda asi
            GameManager.Instance.OnplayerDamage(_damage);
            //se llama al gameover 
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _currentime = _timer;

        //_myRigidbody.gravityScale = _gravity;
    }
    void Update()
    {
        if (_currentime >= 0)
        {
      
            _currentime -= Time.deltaTime;
        }
        else
        {
            _currentime = _timer;
            Jump();
        }
    }
    void Jump()
    {
       
        _myRigidbody.velocity = new Vector2(0, _impulse);
    }
}
