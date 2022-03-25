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
    
    private GameObject _player;
    
    private GameObject _bow;
    
    private GameObject _enemyMov;
    
    private GameObject _enemyDisp;
    
    private GameObject _Camera;

    private CamaraMovement _camMov;

    private bool _menu = true;
    
    private Player_Life_Component _myPlayer_Life_Component;
    
    private Transform _finishLine;
    public LevelManager _levelManager;
    
    
    private void Awake()
    {
       


        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
           
        }
        DontDestroyOnLoad(gameObject);
    }
    
    public void RestartMatch()
    {
        
        SceneManager.LoadScene("Main Menu");
        //AudioManager.Instance.Play("Menu");
        
    }
   

    public void StartMatch()
    {
        
        //Al darle al botón carga la escena principal
        SceneManager.LoadScene("SampleScene");
        
    }
    public void StartMatch2()
    {
        
        //Al darle al botón carga el tutorial
        SceneManager.LoadScene("Tutorial");
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
        if (level != 0)
        {
            _menu = false;
            _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            _player = _levelManager._player;
            _bow = _levelManager._bow;
            _Camera = _levelManager._Camera;
            _enemyDisp = _levelManager._enemyDisp;
            _enemyMov = _levelManager._enemyMov;
            _finishLine = _levelManager._finishLine;


            _player.SetActive(true);
            _bow.SetActive(true);
            _enemyDisp.SetActive(true);
            _enemyMov.SetActive(true);

            _myPlayer_Life_Component = _player.GetComponent<Player_Life_Component>();
            UIManager.Instance.UpdateScore(true);
            //AudioManager.Instance.Play("Main");
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
        if (_menu==false &&_player == true && _player.transform.position.y >= _finishLine.position.y)
        {
            OnPlayerVictory();
        } 
    }
}
