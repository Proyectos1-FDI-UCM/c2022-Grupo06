using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_Component : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _myPlayerMovement;
    public float moveInput = 0;
    public bool jumpInput;
    static public PlayerInput_Component inst;

    [SerializeField]
    private GameObject _bow;
    private void Awake()
    {
        inst = this;
    }
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetKeyDown("space");
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
