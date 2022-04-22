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
    [SerializeField]
    private GameObject _player;
    private Transform _playerTransform;

    [SerializeField]
    private Transform _nextPlayerPlace;

    [SerializeField]
    private Transform _nextCameraPlace;

    [SerializeField]
    private GameObject _camera;
    private Transform _cameraTransform;

    private void Start()
    {
        _playerTransform = _player.GetComponent<Transform>();
        _cameraTransform = _camera.GetComponent<Transform>();

    }
    public void PasoArriba()
    {
        _player.transform.position = _nextPlayerPlace.position;
        _cameraTransform.position = _nextCameraPlace.position;
    }
}
