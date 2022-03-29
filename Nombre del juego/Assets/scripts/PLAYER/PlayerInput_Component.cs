using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_Component : MonoBehaviour
{
    [SerializeField]
     private PlayerMovement _myPlayerMovement;
     private float moveInput = 0;

    [SerializeField]
    private GameObject _bow;
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _myPlayerMovement.Jump();
            AudioManager.Instance.Play("Jump");
        }
        moveInput= Input.GetAxis("Horizontal");
        _myPlayerMovement.movement(moveInput);

        if (Input.GetMouseButtonDown(1))
        {
            _bow.GetComponent<BowController>().CambioDeFlecha();
            AudioManager.Instance.Play("ArrowChange");
        }
        if (Input.GetKey(KeyCode.R))
        {
            _bow.GetComponent<BowController>().CancelacionDisparo();
        }
    }
}
