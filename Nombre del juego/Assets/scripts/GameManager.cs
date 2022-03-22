using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager _instance;
    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _bow;
    [SerializeField]
    private GameObject _enemyMov;
    [SerializeField]
    private GameObject _enemyDisp;
    [SerializeField]
    private GameObject _Camera;
    //[SerializeField]
    //private GameManager _gameManager;
    [SerializeField]
    private Player_Life_Component _myPlayer_Life_Component;
    [SerializeField]
    private Transform _finishLine;
    bool prueba = false;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
           // _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void RestartMatch()
    {
        SceneManager.LoadScene("Main Menu");
        prueba = false;
    }
   

    public void StartMatch()
    {
        prueba = true;
        //Al darle al botón carga la escena principal
        SceneManager.LoadScene("SampleScene");
    }
    public void StartMatch2()
    {
        prueba = true;
        //Al darle al botón carga el tutorial
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {       
        Time.timeScale = 0.0f;
    }
    public void PlayerDies()
    {
        Player_Life_Component.instance.isAlive = false;
        _bow.SetActive(false);
    }
    public void OnPlyerDamage(int damage)
    {
        _myPlayer_Life_Component.Damage(damage);

    }
    public void EnemyDamage(int Damage, GameObject enemy)
    {
        enemy.GetComponent<Enemy_Life_Component>().Damage(Damage);
    }

    private void OnPlayerVictory()
    {
        Debug.Log("you win");
        Time.timeScale = 0.0f;
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyDisp.SetActive(false);
        _enemyMov.SetActive(false);
        UIManager.Instance.SetVictoryMenu(true);
    }
    private void OnLevelWasLoaded(int level)  //cada vez que se cargue la escena principal
    {
        if (level == 1)
        {
            _player.SetActive(true);
            _bow.SetActive(true);
            _enemyMov.SetActive(true);
            _enemyDisp.SetActive(true);
            UIManager.Instance.UpdateScore(true);
        }
    }
    public void OnPlayerDefeat()
    {
      _enemyDisp.SetActive(false);
      _enemyMov.SetActive(false);      
      _Camera.GetComponent<CamaraMovement>().enabled = false;      
      UIManager.Instance.SetLoseMenu(true);
      _bow.SetActive(false);
      _player.SetActive(false);
      Time.timeScale = 0.0f;
        
    }
    private void Update()
    {
        if (_player.transform.position.y != 0 &&prueba == true && _player == true && _player.transform.position.y < _finishLine.position.y)
        {
            OnPlayerVictory();
        } 
    }
}
