using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region components
    [SerializeField]
    private GameObject _mainMenu;
    [SerializeField]
    private GameObject _ChooseLevel;
    [SerializeField]
    private GameObject _defeatMenu;
    [SerializeField]
    private GameObject _victoryMenu;
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private GameObject _score;
    int score=0;
    public Text scoretext;
    #endregion


    #region instance
    static private UIManager _instance;
    static public UIManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    private void Awake()  //como el GameManager, debemos inicializarlo a lo primero para que vaya preparando todo lo necesario para el juego
    {
        _instance = this;
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            _mainMenu.SetActive(true);
            
            _ChooseLevel.SetActive(false);
        }
    }
    public void Levels()
    {
        _mainMenu.SetActive(false);
        _ChooseLevel.SetActive(true);
    }
    public void StartMatch()
    {
        GameManager.Instance.StartMatch();
    }
    public void Pause()
    {
        Debug.Log("se llama al gm");
        GameManager.Instance.pause();
    }
    public void Restore()
    {
        Debug.Log("se llama al gm");
        GameManager.Instance.Restore();
    }
    public void StartMatch2()
    {
        GameManager.Instance.StartMatch2();
    }
    public void RestartGame()
    {
        GameManager.Instance.RestartMatch();
    }
    public void SetVictoryMenu(bool enabled)
    {
        _victoryMenu.SetActive(enabled);
    }
    public void SetLoseMenu(bool enabled)
    {
        _defeatMenu.SetActive(enabled);

    }
    public void SetPauseMenu(bool enabled)
    {
        _pauseMenu.SetActive(enabled);

    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
    
    public void UpdateScore(bool enabled)
    {
        _score.SetActive(enabled);
        if (enabled)
        {
            scoretext.text = "Score: " + score;
        }
        
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore(true);
    }
}
