using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{
    // Start is called before the first frame update
    #region parametres
    static public Player_Life_Component instance;
    public bool isAlive = true;
    private float timer = 0;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject Render;
    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private int _maxlife;
    private int _currentlife;

    #endregion

    private bool hasdied = false;
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
       
       _currentlife = _maxlife;
        
    }
    void Update()
    {
        if(isAlive == false)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }


    public void Damage(int damage)
    {
        _currentlife -= damage;
        if (_currentlife <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        GameManager.Instance.PlayerDies();
    }
}
