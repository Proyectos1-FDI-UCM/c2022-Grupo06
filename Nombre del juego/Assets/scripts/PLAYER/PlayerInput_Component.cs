using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_Component : MonoBehaviour
{
    [SerializeField]
     private PlayerMovement _myPlayerMovement;
     private float moveInput = 0;

    private Rigidbody2D _rbAr;     //accedo a su Rigidbody
    private bool _flechaTP = true;
    [SerializeField]
    private GameObject _bow;

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey("space"))
        {
            _myPlayerMovement.Jump();
        }
        moveInput= Input.GetAxis("Horizontal");
        _myPlayerMovement.movement(moveInput);
        //un ejemplo de como podr�a ir el movimiento de la flecha
        if (Input.GetKey("up")) 
        {
            Debug.Log("entra");
            _rbAr.gravityScale = 0;       
        }
        else if (Input.GetKey("down"))
        {
            Debug.Log("entra");
            _rbAr.gravityScale = 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _bow.GetComponent<BowController>().CambioDeFlecha();
        }
        if (Input.GetKey(KeyCode.R))
        {
            _bow.GetComponent<BowController>().CancelacionDisparo();
        }

        //la gravedad deber�a cambiarse en el script Arrow, esto era simplemente testeo
    }
}
