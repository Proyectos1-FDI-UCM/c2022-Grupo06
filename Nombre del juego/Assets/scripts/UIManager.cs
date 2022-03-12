using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _mainMenu;
    static private UIManager _instance;
    static public UIManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public void SetMainMenu(bool enabled)
    { //permite activar o desactivar el menu inicial
        _mainMenu.SetActive(enabled);
    }
    public void StartMatch()
    {
        GameManager.Instance.StartMatch();
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
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
