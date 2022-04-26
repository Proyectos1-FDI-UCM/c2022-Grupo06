using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowInhib : MonoBehaviour
{
    [SerializeField]
    private GameObject _bow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _bow.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _bow.SetActive(true);
    }
}
