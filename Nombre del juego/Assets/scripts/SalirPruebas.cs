using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirPruebas : MonoBehaviour
{
    [SerializeField]
    private GameObject _inicioTutorial_Player;

    [SerializeField]
    private GameObject _inicioTutorial_Camara;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>())
        {
            GameManager.Instance._player.transform.position = _inicioTutorial_Player.transform.position;
            GameManager.Instance._Camera.transform.position = _inicioTutorial_Camara.transform.position;
            GameManager.Instance._Camera.GetComponent<ZonaPruebasCameraMovement>().enabled = false;
            GameManager.Instance._Camera.GetComponent<CamaraMovement>().enabled = true;
            GameManager.Instance._Camera.GetComponent<CamaraMovement>()._vel = 0.001f;
        }
    }
}
