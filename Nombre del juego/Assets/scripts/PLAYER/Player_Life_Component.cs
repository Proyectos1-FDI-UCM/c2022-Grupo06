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
    public void Damage(int _damage)
    {
        Debug.Log(_currrentlife);
        _currrentlife -= _damage;
        if (_currrentlife <= 0)
        {
            GameManager.Instance.GameOver();            
        }
    }
}
