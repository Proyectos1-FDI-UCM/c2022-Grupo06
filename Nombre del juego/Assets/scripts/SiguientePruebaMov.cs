using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguientePruebaMov : MonoBehaviour
{
    [SerializeField]
    public GameObject _luz;
    [SerializeField]
    private GameObject _siguienteZona;

    [SerializeField]
    private GameObject _siguienteZonaCamara;
    public Transform _playerTransform;
    public Transform _cameraTransform;

    public GameObject _player;

    public GameObject _camera;

    public bool _cameraControl = false;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameManager.Instance._player;
        _camera = GameManager.Instance._Camera;
        _playerTransform = _player.GetComponent<Transform>();
        _cameraTransform = _camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _player.transform.position = _siguienteZona.transform.position;
            _camera.GetComponent<ZonaPruebasCameraMovement>().nextPlace = _siguienteZonaCamara.transform;
            //this.enabled = false;
            gameObject.SetActive(false);
        }

    }
}
