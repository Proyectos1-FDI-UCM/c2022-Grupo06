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
        SceneManager.LoadScene("Main Menu");
    }
    public void StartMatch()
    {
        //Al darle 
        //activa cada uno de los personajes, el mov de la cámara y quita el menú principal
        //_player.SetActive(true);
        //_bow.SetActive(true);
        //_enemyMov.SetActive(true);
        //_enemyDisp.SetActive(true);
        //_Camera.GetComponent<CamaraMovement>().enabled = true;
        UIManager.Instance.SetMainMenu(false);
        UIManager.Instance.UpdateScore(true);
        SceneManager.LoadScene("SampleScene");


    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        Time.timeScale = 0.0f;
        _player.SetActive(false);
        UIManager.Instance.UpdateScore(false);
        _bow.SetActive(false);
        _enemyMov.SetActive(false);
        _enemyDisp.SetActive(false);
        //_Camera.GetComponent<CamaraMovement>().enabled = false;
        SceneManager.LoadScene("Main Menu");
        UIManager.Instance.SetMainMenu(true);
        
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
        //Debug.Log("daño enemigo"+Damage);
        enemy.GetComponent<Enemy_Life_Component>().Damage(Damage);
    }

    private void OnPlayerVictory()
    {   
        Time.timeScale = 0.0f;
        //_player.SetActive(false);
        //_bow.SetActive(false);
        //_enemyDisp.SetActive(false);
        //_enemyMov.SetActive(false);
        //UIManager.Instance.SetVictoryMenu(true);
        //_Camera.GetComponent<CamaraMovement>().enabled = false;
        SceneManager.LoadScene("SampleScene");
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

       
    }
}
