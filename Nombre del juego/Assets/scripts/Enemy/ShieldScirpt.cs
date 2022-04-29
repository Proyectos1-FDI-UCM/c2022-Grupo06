using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScirpt : MonoBehaviour
{
    
    private Transform _boss;
    private Transform _myTransform;
    void Start()
    {
        _myTransform = GetComponent<Transform>();
        _boss = GameManager.Instance._levelManager._boss.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.RotateAround(_boss.transform.forward, Vector3.right, 20 * Time.deltaTime);
    }
}
