using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesPruebasDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject _luz;
    [SerializeField]
    private GameObject _siguienteLuzCollider;
    [SerializeField]
    private GameObject _siguienteLuz;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInput_Component>())
        {
            _luz.SetActive(false);

            _siguienteLuz.SetActive(true);

            _siguienteLuzCollider.SetActive(true);
        }
    }
}
