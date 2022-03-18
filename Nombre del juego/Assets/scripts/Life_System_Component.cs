using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_System_Component : MonoBehaviour
{
    #region parametres
    [SerializeField]
    protected int _maxlife;
    protected  int _currentlife;
    [SerializeField]
    int enemyscore = 10;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _currentlife = _maxlife;
        Debug.Log(_currentlife);
    }
    public void Damage(int Damage)
    {
       // Debug.Log("daño que entra" + Damage+"vida "+_currentlife);
        _currentlife -= Damage;
        //Debug.Log(_currentlife);
        if (_currentlife <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (this.gameObject.GetComponent<Player_Life_Component>())
        {
            GameManager.Instance.PlayerDies();

        }
        else
        {
            gameObject.SetActive(false);
            UIManager.Instance.AddScore(enemyscore);
        }

    }
    

}
