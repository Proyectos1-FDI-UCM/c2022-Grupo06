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
    private GameManager _gameManager;
    private void Awake()
    {
        _instance = this;
    }
    public void StartMatch()
    {
        _player.SetActive(true);
        _bow.SetActive(true);
        UIManager.Instance.SetMainMenu(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        _player.SetActive(false);
        _bow.SetActive(false);
        UIManager.Instance.SetMainMenu(true);
    }
}
