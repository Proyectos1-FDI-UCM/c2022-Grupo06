using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] _lvlZones = new GameObject[5];
    static private GeneratorComponent _instance;
    private Transform _myTransform;
    int random, up, down, middle;
    static public GeneratorComponent Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }

    }
    private void Start()
    {
        _myTransform = GetComponent<Transform>();
        Debug.Log(_myTransform.position);
        down = 0;
        middle = 1;
        up = 2;
    }
    public void CambioPos()
    {
        
        random = Random.Range(0, 5);
        Debug.Log(random);
        while(_lvlZones[random].activeSelf == true)
        {
            random = Random.Range(0, 5);
        }
        _lvlZones[random].transform.position = _myTransform.position;
        _lvlZones[random].SetActive(true);
        _lvlZones[random].GetComponent<RespawnEnemies>().RespawnZoneEnemies();
        _lvlZones[down].SetActive(false);
        down = middle;
        middle = up;
        up = random;
        _myTransform.position = _myTransform.position + (Vector3.up * 19.0f);
    }
}
