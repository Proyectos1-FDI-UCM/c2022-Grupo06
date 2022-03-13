using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyLifeComponent>())
        {
            GameManager.Instance.OnPlayerDefeat();
        }
    }
}
