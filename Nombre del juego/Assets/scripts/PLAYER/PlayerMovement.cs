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
            _myRigidBody.velocity = new Vector2(0, 1);
        }

        if (_myRigidBody.velocity.y == 0) isGrounded = true;
        else isGrounded = false;

        if (isGrounded)
        {
            if(PlayerInput_Component.inst.jumpInput) _myRigidBody.velocity = new Vector2(_myRigidBody.velocity.x, impulse);
            
            _isDashing = false;
            _hasDashed = false;
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
        if (moveInput != 0)
        {
            _myRigidBody.velocity = new Vector2(moveInput * moveSpeed, _myRigidBody.velocity.y);
            if (moveInput > 0)
            {
                //si es mayor que cero va hacia la derecha, sprite por defecto
                pTransform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                //si es menor que cero va a la izq, rotar el sprite
                pTransform.eulerAngles = new Vector3(0, 180, 0);
            }
            //_myRigidBody.MovePosition((Vector2)transform.position + movimiento * Time.deltaTime);
        }
        else if (!_isDashing)
        {
            _myRigidBody.velocity = new Vector2(0, _myRigidBody.velocity.y);
        }
    }

    public void Dash(Vector2 vec)
    {
        _myRigidBody.inertia = 0;
        _myRigidBody.velocity = new Vector2(vec.x / 1.5f * _dashSpeed, vec.y / 1.5f * _dashSpeed);
        //_myRigidBody.AddForce(new Vector2(vec.x / 1.5f * _dashSpeed, vec.y / 1.5f * _dashSpeed), ForceMode2D.Impulse);
        _dashCD = 0;
    }
}
