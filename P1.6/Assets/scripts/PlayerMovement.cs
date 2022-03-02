using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float gInterval;
    private float gProg = 0;
    public bool pIsLookingRight = true;
    [SerializeField]
    private float _gravity = 4.0f;
    [SerializeField]
    private checkGround _mycheckGround;
    void Start()
    {
        pInstance = this;
        pTransform = transform;
        _myRigidBody = GetComponent<Rigidbody2D>();        
    }

   
    public void Jump()
    {
        
        if (isGrounded)
        {
            _myRigidBody.velocity = new Vector2(_myRigidBody.velocity.x, impulse);//a partir de la velocidad que tiene en el eje x, se leañade verticalmente una vel.
        }
    }
    public void movement(float moveInput)
    {
        _myRigidBody.gravityScale = _gravity;
        isGrounded = _mycheckGround.Suelo(isGrounded);

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

        if (moveInput > 0)
        {//si es mayor que cero va hacia la derecha, sprite por defecto
            pTransform.eulerAngles = new Vector3(0, 0, 0);
      
        }
        else if (moveInput < 0)
        {//si es menor que cero va a la izq, rotar el sprite
            pTransform.eulerAngles = new Vector3(0, 180, 0);
      
        }
        _myRigidBody.velocity = new Vector2(moveInput * moveSpeed, _myRigidBody.velocity.y);
    }
    
}
