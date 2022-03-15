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
    private GameManager _gameManager;
    
   
    private void Awake()
    {
        _instance = this;
    }
    public void StartMatch()
    {
        _player.SetActive(true);
        _bow.SetActive(true);
        _enemyMov.SetActive(true);
        UIManager.Instance.SetMainMenu(false);
        
        
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
        UIManager.Instance.SetMainMenu(true);
        UIManager.Instance.UpdateScore();
        
    }
    public void PlayerDies()
    {
        Player_Life_Component.instance.isAlive = false;
        _bow.SetActive(false);
    }
}
