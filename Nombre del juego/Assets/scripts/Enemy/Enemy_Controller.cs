using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    #region parametres
    [SerializeField]
    private int _damageontouch;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow2>())
        {

            gameObject.SetActive(false);
        }
        else if (collision.gameObject.GetComponent<Player_Life_Component>())
        {
            GameManager.Instance.OnplayerDamage(_damageontouch);
        }
    }
}
