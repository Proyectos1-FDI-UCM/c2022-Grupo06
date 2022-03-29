using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Components
    [SerializeField]
    public GameObject _player;
    [SerializeField]
    public GameObject _bow;
    [SerializeField]
    public GameObject _enemyMov;
    [SerializeField]
    public GameObject _enemyDisp;
    [SerializeField]
    public GameObject _Camera;
    [SerializeField]
    public Transform _finishLine;
    #endregion

    static private LevelManager _instance;
    static public LevelManager Instance
    {
        get
        {
            return _instance;
        }
    }

}
