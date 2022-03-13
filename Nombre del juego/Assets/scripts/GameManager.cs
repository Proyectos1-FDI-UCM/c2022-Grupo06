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

    [SerializeField]
    private Transform _finishLine;                            //donde acabaríamos el nivel
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
    private void OnPlayerVictory()
    {
        Time.timeScale = 0.0f;
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyMov.SetActive(false);
        UIManager.Instance.SetVictoryMenu(true);
    }
    public void OnPlayerDefeat()
    {
        Time.timeScale = 0.0f;
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyMov.SetActive(false);
        UIManager.Instance.SetLoseMenu(true);
    }
    void Start()
    {
        Time.timeScale = 0.0f;                              //falta desactivar el componente de la cámra      
        _player.SetActive(false);
        _bow.SetActive(false);
        _enemyMov.SetActive(false);
        UIManager.Instance.SetMainMenu(true);
    }
    private void Update()
    {
        if (_player.transform.position.y >= _finishLine.position.y)
        {
            OnPlayerVictory();
        }
    }
}
