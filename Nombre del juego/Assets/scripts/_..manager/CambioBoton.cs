using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioBoton : MonoBehaviour
{

    static private CambioBoton _instance;
    static public CambioBoton Instance
    {
        get
        {
            return _instance;
        }
    }
    
    private GameObject _player;
    private Transform _playerTransform;

    [SerializeField]
    private Transform _nextPlayerPlace;
    private bool _cameraControl;

    [SerializeField]
    private Transform _nextCameraPlace;

    
    private GameObject _camera;
    private Transform _cameraTransform;

    private void Start()
    {
        _player = GameManager.Instance._player;
        _camera = GameManager.Instance._Camera;
        _playerTransform = _player.GetComponent<Transform>();
        _cameraTransform = _camera.GetComponent<Transform>();

    }
    public void PasoArriba()
    {
        _playerTransform.position = _nextPlayerPlace.position;
        _cameraControl = true;
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
