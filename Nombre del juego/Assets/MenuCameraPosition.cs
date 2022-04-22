using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject fondo;

    private Transform _mytransform;
    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 25 && GetComponent<CamaraMovement>()._vel>0)
        {
            //fondo.transform.parent = _mytransform;
            GetComponent<CamaraMovement>()._vel = GetComponent<CamaraMovement>()._vel * -2;
            
        }
        if (transform.position.y <1 && GetComponent<CamaraMovement>()._vel<0)
        {
            //fondo.transform.parent = _mytransform;
            GetComponent<CamaraMovement>()._vel = GetComponent<CamaraMovement>()._vel * -1/2;
        }
    }
}
