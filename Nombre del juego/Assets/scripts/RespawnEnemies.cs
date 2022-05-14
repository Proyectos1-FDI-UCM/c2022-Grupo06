using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _enemiesList;

    public void RespawnZoneEnemies()
    {
        foreach (GameObject _enemies in _enemiesList)
        {
            _enemies.SetActive(true);
        }
    }
}
