using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestruction : MonoBehaviour
{
    [SerializeField]
    private GameObject Posboos;
    [SerializeField]
    private GameObject Posplayer;

     private Transform transform;
    Transform a;
    Transform b;

    private void Start()
    {
        transform =GetComponent<Transform>();
        a = Posboos.GetComponent<Transform>();
        b = Posplayer.GetComponent<Transform>();
        transform.position = ((a.position + b.position) / 2) + b.position;
        Debug.Log(a.position+ "pos enemigo" + b.position + "posicion bloque" + transform.position);
        Debug.Log(b.position.x);
        Debug.Log(b.position.y);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow2>())
        {
            Destroy(gameObject);
        }
    }
}
