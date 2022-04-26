using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _randomManager;

    [SerializeField]
    private GameObject _ultimaLuz;

    [SerializeField]
    private GameObject _luzActual;
    [SerializeField]
    private GameObject _cartelSalida;
    [SerializeField]
    private GameObject _ultimocllider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput_Component>())
        {
            _randomManager.SetActive(true);
            this.gameObject.SetActive(false);
            _ultimaLuz.SetActive(true);
            _ultimocllider.SetActive(true);
            _cartelSalida.SetActive(true);
            _luzActual.SetActive(false);
        }
    }
}
