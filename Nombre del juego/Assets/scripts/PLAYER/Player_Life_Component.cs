using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{
    #region parametres
    [SerializeField]
    private int _maxlife;
    private int _currrentlife;
    #endregion
    void Start()
    {
        _currrentlife = _maxlife;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyLifeComponent>())
        {
            GameManager.Instance.OnPlayerDefeat();
        }
    }
    public void Damage(int _damage)
    {
        _currrentlife -= _maxlife;
        if (_currrentlife <= 0)
        {
            GameManager.Instance.GameOver();
            Debug.Log("chiki");
        }
    }
}
