using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{
    #region
    [SerializeField]
    private int _maxlive;
    private int _currentlife;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _currentlife = _maxlive;
    }
    public void Damage(int damage)
    {
        _currentlife -= damage;
        if (_currentlife <= 0)
        {
            GameManager.Instance.OnplayerDies();
            Debug.Log("finiquitao");
        }
    }

    
}
