using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCamMov : MonoBehaviour
{
    [SerializeField]
    private GameObject _lastCamPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance._Camera.GetComponent<CamaraMovement>().enabled = false;
        GameManager.Instance._Camera.transform.position = _lastCamPos.transform.position;
    }
}
