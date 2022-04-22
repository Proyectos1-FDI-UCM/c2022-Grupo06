using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region instance
    static private GameManager _instance;
    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    #region components
    public  GameObject _player;
    
    private GameObject _bow;
    
    private GameObject _enemyMov;
    
    private GameObject _enemyDisp;
    
    public  GameObject _Camera;

    private CamaraMovement _camMov;

    private bool _menu = true;

    private bool _arcade = false;
    
    private Player_Life_Component _myPlayer_Life_Component;
    
    private Transform _finishLine;

    public LevelManager _levelManager;

    public Transform _boss;

    #endregion


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
    
   
    public void StartMatch()
    {
        _arcade = false;
        //Al darle al bot�n carga la escena principal
        SceneManager.LoadScene("SampleScene");
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("Main");
    }
    public void StartMatch2()
    {
        _arcade = false;
        //Al darle al bot�n carga el tutorial
        SceneManager.LoadScene("Tutorial");
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("Tutorial");
    }
    public void StartArcade()
    {
        _arcade = true;
        //Al darle al bot�n carga el modo arcade
        SceneManager.LoadScene("ArcadeScene");
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("Tutorial");
    }
    public void RestartMatch()
    {
        SceneManager.LoadScene("Main Menu");
        AudioManager.Instance.Stop("Win");
        AudioManager.Instance.Stop("Lose");
        AudioManager.Instance.Play("Menu");

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {       
        Time.timeScale = 0.0f;
        AudioManager.Instance.Play("Menu");
        _arcade = false;
    }
    public void PlayerDies()
    {
        Player_Life_Component.instance.isAlive = false;
        _bow.SetActive(false);
        OnPlayerDefeat();
    }
    public void OnPlyerDamage(int damage)
    {
        _myPlayer_Life_Component.Damage(damage);

    }
    public void EnemyDamage(int Damage, GameObject enemy)
    {
        enemy.GetComponent<Enemy_Life_Component>().Damage(Damage);

    }
    public void pause()
    {
        Time.timeScale = 0.0f;
        Debug.Log("se llama a metodo");
        _bow.SetActive(false);
        _enemyDisp.SetActive(false);
        _enemyMov.SetActive(false);
        UIManager.Instance.SetPauseMenu(true);
        _Camera.GetComponent<CamaraMovement>().enabled = false;
    }
    public void Restore()
    {
        UIManager.Instance.SetPauseMenu(false);
        Time.timeScale = 1.0f;
        Debug.Log("se llama a metodo 2");
        _bow.SetActive(true);
        _enemyDisp.SetActive(true);
        _enemyMov.SetActive(true);
        
        _Camera.GetComponent<CamaraMovement>().enabled = true;
    }

    public void OnPlayerVictory()
    {
        Debug.Log("you win");
        Time.timeScale = 0.0f;
        _player.SetActive(false);
        _bow.SetActive(false);
        //_enemyDisp.SetActive(false);
        //_enemyMov.SetActive(false);
        AudioManager.Instance.Stop("Main");
        AudioManager.Instance.Stop("Tutorial");
        AudioManager.Instance.Play("Win");
        UIManager.Instance.SetVictoryMenu(true);
        
    }

   

    private void OnLevelWasLoaded(int level)  //cada vez que se cargue la escena principal
    {
        if (level != 0)
        {
            _menu = false;
            _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            if (level == 3)
            {
                //en caso de ser el arcade
                _player = _levelManager._player;
                _bow = _levelManager._bow;
                _Camera = _levelManager._Camera;
                _player.SetActive(true);
                _bow.SetActive(true);
                _myPlayer_Life_Component = _player.GetComponent<Player_Life_Component>();
                UIManager.Instance.UpdateScore(true);
            }
            else
            {
                _player = _levelManager._player;
                _bow = _levelManager._bow;
                _Camera = _levelManager._Camera;
                _enemyDisp = _levelManager._enemyDisp;
                _enemyMov = _levelManager._enemyMov;
                _finishLine = _levelManager._finishLine;
                if (level == 1)
                {
                    _boss = _levelManager._boss;
                }
                _player.SetActive(true);
                _bow.SetActive(true);
                _enemyDisp.SetActive(true);
                _enemyMov.SetActive(true);

                _myPlayer_Life_Component = _player.GetComponent<Player_Life_Component>();
                UIManager.Instance.UpdateScore(true);
            }
            
        }
    }
    public void OnPlayerDefeat()
    {
        //_enemyDisp.SetActive(false);
        //_enemyMov.SetActive(false);
        if (_arcade) { _Camera.GetComponent<CameraArcade>().enabled = false; }
        else { _Camera.GetComponent<CamaraMovement>().enabled = false; }
        AudioManager.Instance.Stop("Main");
        AudioManager.Instance.Stop("Tutorial");
        AudioManager.Instance.Play("Lose");
        UIManager.Instance.SetLoseMenu(true);
        _bow.SetActive(false);
        _player.SetActive(false);
        Time.timeScale = 0.0f;
    }
    
}
