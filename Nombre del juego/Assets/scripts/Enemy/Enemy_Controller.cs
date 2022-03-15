using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Controller : MonoBehaviour
{
    #region parametres
    [SerializeField]
    private int _damageontouch;
    [SerializeField]
    int enemyscore = 10;

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow2>())
        {
           
            gameObject.SetActive(false);
            UIManager.Instance.AddScore(enemyscore);
           
        }
        else if (collision.gameObject.GetComponent<Player_Life_Component>())
        {
            GameManager.Instance.PlayerDies();
        }
    }
}
