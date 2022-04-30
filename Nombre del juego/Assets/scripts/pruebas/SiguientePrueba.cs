using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguientePrueba : MonoBehaviour
{
    [SerializeField]
    public Transform _nextPlace;
    [SerializeField]
    public Transform _nextCameraPlace;

    public Transform _playerTransform;
    public Transform _cameraTransform;

    public GameObject _player;

    public GameObject _camera;

    public bool _cameraControl = false;


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
            _camera.GetComponent<ZonaPruebasCameraMovement>().nextPlace = _nextCameraPlace;
        }
    }

    private void Update()
    {
    }
}
