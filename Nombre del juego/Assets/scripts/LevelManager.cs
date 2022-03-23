using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
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

    static private LevelManager _instance;
    static public LevelManager Instance
    {
        get
        {
            return _instance;
        }
    }

}
