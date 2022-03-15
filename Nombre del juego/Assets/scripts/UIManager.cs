using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _mainMenu;
    [SerializeField]
    private GameObject _defeatMenu;
    [SerializeField]
    private GameObject _victoryMenu;

    #region score
    [SerializeField]
    int score=0;
    public Text scoretext;
    #endregion
    static private UIManager _instance;
    static public UIManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public void SetMainMenu(bool enabled)
    {                                           //permite activar o desactivar el menu inicial
        _mainMenu.SetActive(enabled);
    }
    public void SetVictoryMenu(bool enabled)
    {
        _victoryMenu.SetActive(enabled);
    }
    public void SetLoseMenu(bool enabled)
    {
        _defeatMenu.SetActive(enabled);
    }
    public void StartMatch()
    {
         GameManager.Instance.StartMatch();
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
    
    public void UpdateScore()
    {
        scoretext.text = "Score: " + score;
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    
    private void Awake()             //como el GameManager, debemos inicializarlo a lo primero para que vaya preparando todo lo necesario para el juego
    { 
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
