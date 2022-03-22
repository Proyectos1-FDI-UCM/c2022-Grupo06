using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public Transform pTransform;
    public Rigidbody2D _myRigidBody;
    [SerializeField]
    private float moveSpeed;
    private bool isGrounded = false;
    [SerializeField]
    private float impulse;
    static public PlayerMovement pInstance;//cosa de animacion de marvin

    private float gProg = 0;
    public bool pIsLookingRight = true;
    [SerializeField]
    private float _gravity = 4.0f;

    private bool _hasDashed;
    [SerializeField]
    private float _dashSpeed;
    private float _dashCD=0;
    [SerializeField]
    private float _dashDur;
    private bool _isDashing;
    private Vector2 _dir;
    private float _dashPr;
    [SerializeField]
    private GameObject ghost;
    [SerializeField]
    private int ghosts;
    private float gInterval;
    void Start()
    {
        pInstance = this;
        pTransform = transform;
        _myRigidBody = GetComponent<Rigidbody2D>();
        gInterval = _dashDur / ghosts;
    }

    public void Update()
    {
        if (!_isDashing)
        {
            PLAYERANIM.pANIMATOR.isDashing = false;
            gProg = 0;
            _myRigidBody.gravityScale = _gravity;
            _myRigidBody.drag = 0.05f;
            _dashCD += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E) && _dashCD >= 0.25f && !_hasDashed)
        {
            _hasDashed = true;
            _isDashing = true;
            Vector2 bPos = pTransform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 Dir = mousePos - bPos;
            Dir.Normalize();
            _dir = Dir;
            if (_dir.x < 0)
            {
                pTransform.eulerAngles = new Vector3(0, 180, 0);
                pIsLookingRight = false;
            }
            else if (_dir.x > 0)
            {
                pTransform.eulerAngles = new Vector3(0, 0, 0);
                pIsLookingRight = true;
            }
            _myRigidBody.velocity = new Vector2(0, 0);
            Dash(_dir);
        }
        if (_isDashing)
        {
            _hasDashed = true;
            PLAYERANIM.pANIMATOR.isDashing = true;
            _dashPr += Time.deltaTime;

            gProg += Time.deltaTime;
            if (gProg >= gInterval)
            {
                Instantiate(ghost, pTransform.position, Quaternion.identity);
                gProg = 0;
            }

            _myRigidBody.gravityScale = 0;
            _myRigidBody.drag = 0;
        }
        if (_dashPr >= _dashDur)
        {
            _hasDashed = true;
            _dashPr = 0;
            _isDashing = false;
        }

        if (_myRigidBody.velocity.y == 0) isGrounded = true;
        else isGrounded = false;

        if (isGrounded)
        {
            _myRigidBody.velocity = new Vector2(0, 0);
            _isDashing = false;
            _hasDashed = false;
        }
    }
    public void Jump()
    {
        if (isGrounded)
        {
            _myRigidBody.velocity = new Vector2(_myRigidBody.velocity.x, impulse);//a partir de la velocidad que tiene en el eje x, se leañade verticalmente una vel.
            //FindObjectOfType<AudioManager>().Play(""); //esto es una funcion que se puede utilizar de vez en cuando para buscar el objeto de ese tipo
        }
    }
    public void movement(float moveInput)
    {
        _myRigidBody.gravityScale = _gravity;
        #region animaciones marvin
        if (_myRigidBody.velocity.y > 0 && !isGrounded)
        {
            PLAYERANIM.pANIMATOR.isJumping = true;
        }
        else if (_myRigidBody.velocity.y < 0 && !isGrounded)
        {
            PLAYERANIM.pANIMATOR.isJumping = false;
            PLAYERANIM.pANIMATOR.isFalling = true;
        }
        if (isGrounded)
        {
            PLAYERANIM.pANIMATOR.isJumping = false;
            PLAYERANIM.pANIMATOR.isFalling = false;
        }
        if (moveInput != 0)
        {
            PLAYERANIM.pANIMATOR.isRunning = true;
        }
        else
        {
            PLAYERANIM.pANIMATOR.isRunning = false;
        }
        #endregion
        if(moveInput != 0)
        {
            Vector2 movimiento = new Vector2(moveSpeed * Mathf.Abs(moveInput), _myRigidBody.velocity.y);
            movimiento *= Time.deltaTime;

            pTransform.Translate(movimiento);
        }
        if (moveInput > 0)
        {//si es mayor que cero va hacia la derecha, sprite por defecto
            pTransform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {//si es menor que cero va a la izq, rotar el sprite
            pTransform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void Dash(Vector2 vec)
    {
        _myRigidBody.inertia = 0;
        _myRigidBody.AddForce(new Vector2(vec.x / 1.5f * _dashSpeed, vec.y / 1.5f * _dashSpeed), ForceMode2D.Impulse);
        _dashCD = 0;
    }
}
