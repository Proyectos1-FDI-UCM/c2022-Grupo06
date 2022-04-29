using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestruction : MonoBehaviour
{
    [SerializeField]
    private Transform Posboss;
    private GameObject Posplayer;
    private Transform _mytransform;
   

    private void Start()
    {
        //Posplayer = GameManager.Instance._player;
        //Posboss = GameManager.Instance._boss;
        //_mytransform =GetComponent<Transform>();
        //_mytransform.position = ((Posboss.position + Posplayer.transform.position) / 2) ;
        //Debug.Log("pos enemigo" + Posboss.position+ "pos personaje" + Posplayer.transform.position + "posicion bloque" + transform.position);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Arrow2>())
        {
            Destroy(gameObject);
        }
    }
}
