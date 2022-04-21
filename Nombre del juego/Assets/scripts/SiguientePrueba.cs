using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguientePrueba : MonoBehaviour
{
    [SerializeField]
    private Transform _nextPlace;
    [SerializeField]
    private Transform _nextCameraPlace;

    private Transform _playerTransform;
    private Transform _cameraTransform;

    private GameObject _player;

    private GameObject _camera;

    private bool _cameraControl = false;


    void Start()
    {
        _player = GameManager.Instance._player;
        _camera = GameManager.Instance._Camera;
        _playerTransform = _player.GetComponent<Transform>();
        _cameraTransform = _camera.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput_Component>())
        {
            _playerTransform.position = _nextPlace.position;
            _cameraControl = true;
                
        }
    }

    private void Update()
    {
        if (_cameraControl == true)
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _nextCameraPlace.position, Time.deltaTime);
        }

        if (_cameraTransform.position == _nextCameraPlace.position)
        {
            _cameraControl = false;
        }
       
    }
}
