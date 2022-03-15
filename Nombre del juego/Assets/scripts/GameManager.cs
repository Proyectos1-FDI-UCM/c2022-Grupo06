using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Transform _finishLine;                            //donde acabaríamos el nivel
    private void Awake()
    {
        _instance = this;
    }
    public void StartMatch()
    {
        //activa cada uno de los personajes, el mov de la cámara y quita el menú principal
        _player.SetActive(true);
        _bow.SetActive(true);
        _enemyMov.SetActive(true);
        _enemyDisp.SetActive(true);
        _Camera.GetComponent<CamaraMovement>().enabled = true;
        UIManager.Instance.SetMainMenu(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void OnPlayerVictory()
    {
        Time.timeScale = 0.0f;
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyMov.SetActive(false);
        UIManager.Instance.SetVictoryMenu(true);
    }
    void Start()
    {
        Time.timeScale = 0.0f;                              //falta desactivar el componente de la cámra      
       
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyMov.SetActive(false);
        _enemyDisp.SetActive(false);
        _Camera.GetComponent<CamaraMovement>().enabled = false;
        UIManager.Instance.SetMainMenu(true);
    }
   
    public void OnplayerDamage(int damage)
    {
        _myPlayer_Life_Component.Damage(damage);
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyMov.SetActive(false);
        UIManager.Instance.SetLoseMenu(true);
    }
    private void Update()
    {
        if (_player.transform.position.y >= _finishLine.position.y)
        {
            OnPlayerVictory();
        }
    }

}
