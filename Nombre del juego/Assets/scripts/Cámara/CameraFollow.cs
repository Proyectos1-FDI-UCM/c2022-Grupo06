using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject _myCamara;
    private CamaraMovement _camaraMov;
    private GameObject _myPlayer;
    [SerializeField]
    private float _accelOffset = 2;
    [SerializeField]
    private float _velocidadReajuste = 0.012f;

    void Start()
    {
        
        _myPlayer = GameManager.Instance._player;
        _myCamara = GameManager.Instance._Camera;
        _camaraMov = _myCamara.GetComponent<CamaraMovement>();
    }

    private void Update()
    {
        if (_myPlayer.transform.position.y >= _myCamara.transform.position.y+ _accelOffset)
        {
            _camaraMov._vel = _velocidadReajuste;   
        }
        else
        {
            _camaraMov._vel = _camaraMov._velInicial;
        }
    }

}
