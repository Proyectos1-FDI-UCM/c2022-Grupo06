using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement_Component : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Transform _myTransform;
    [SerializeField]
    private Transform [] posiciones;
    int i=0;
    Vector3 nexPos;
    // Start is called before the first frame update
    void Start()
    {
        nexPos = posiciones[i+1].transform.position;
        _myTransform = GetComponent<Transform>();
        _myTransform.position = posiciones[i].transform.position;
    }
    void Update()
    {
        if (_myTransform.position == nexPos)
        {
            i= (i+1)%posiciones.Length;
            nexPos = posiciones[(i + 1) % posiciones.Length].transform.position;
        }
        _myTransform.position = Vector3.MoveTowards(_myTransform.position, nexPos, speed * Time.deltaTime); //donde esta, a donde va y con que velocidad

    }
    
   
    
}
