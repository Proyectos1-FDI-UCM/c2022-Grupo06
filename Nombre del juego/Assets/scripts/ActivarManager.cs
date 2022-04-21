using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _randomManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput_Component>())
        {
            Debug.Log("entra");
            _randomManager.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
