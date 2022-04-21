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

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _camera;


    void Start()
    {
        _playerTransform = _player.GetComponent<Transform>();
        _cameraTransform = _camera.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput_Component>())
        {
            _playerTransform.position = _nextPlace.position;
                 
        }
    }

    private void Update()
    {
        _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _nextCameraPlace.position, Time.deltaTime);
    }
}
