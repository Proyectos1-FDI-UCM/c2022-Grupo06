using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _lvlZones = new GameObject[5];

    int random;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GeneratorComponent>())
        {
            Debug.Log("Generando nueva zona...");
            Instantiate(_lvlZones[Random.Range(0, 5)], new Vector3(0, transform.position.y, 0), Quaternion.identity);
        }
    }

}
