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
    [SerializeField]
    public GameObject _menumusic;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private Player_Life_Component _myPlayer_Life_Component;
    [SerializeField]
    private Enemy_Life_Component _myEnemy_Life_Component;
    [SerializeField]
    private Transform _finishLine;

    
   
    private void Awake()
    {
        _instance = this;
    }
    public void RestartMatch()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void StartMatch()
    {
        //activa cada uno de los personajes, el mov de la cámara y quita el menú principal
        _player.SetActive(true);
        _bow.SetActive(true);
        _enemyMov.SetActive(true);
        _enemyDisp.SetActive(true);
        _Camera.GetComponent<CamaraMovement>().enabled = true;
        _Camera.GetComponent<CamaraMovement>().Audio(true);
        UIManager.Instance.SetMainMenu(false);
        UIManager.Instance.UpdateScore(true);
        //testing para parar el audio
        _menumusic.GetComponent<MenuMusic>().mute(true);
        _menumusic.GetComponent<MenuMusic>().Sound(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        Time.timeScale = 0.0f;
       
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyMov.SetActive(false);
        _enemyDisp.SetActive(false);
        _Camera.GetComponent<CamaraMovement>().enabled = false;
        UIManager.Instance.SetMainMenu(true);
        UIManager.Instance.UpdateScore(false);
        _menumusic.GetComponent<MenuMusic>().Sound(true);


    }
    public void PlayerDies()
    {
        Player_Life_Component.instance.isAlive = false;
        _bow.SetActive(false);
        _bow.SetActive(false);
        

    }
    public void OnPlayerDamage(int damage)
    {
        _myPlayer_Life_Component.Damage(damage);

    }
    public void EnemyDamage(int Damage, GameObject enemy)
    {
        //Debug.Log("daño enemigo"+Damage);
        enemy.GetComponent<Enemy_Life_Component>().Damage(Damage);
    }

    private void OnPlayerVictory()
    {   
        Time.timeScale = 0.0f;
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyDisp.SetActive(false);
        _enemyMov.SetActive(false);
        UIManager.Instance.SetVictoryMenu(true);
<<<<<<< Updated upstream
        _Camera.GetComponent<CamaraMovement>().enabled = false;
        

=======
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
          //  AudioManager.Instance.Play("Main");
        }
       
>>>>>>> Stashed changes
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
        if (_player.transform.position.y >= _finishLine.position.y)
        {
            OnPlayerVictory();
        }

        //testing
        if (Input.GetAxis("Vertical") == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
