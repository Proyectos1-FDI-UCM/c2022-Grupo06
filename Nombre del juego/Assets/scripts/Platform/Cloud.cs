using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public bool InicioCuentra = false;
    [SerializeField]
    public float cont;
    private float _elapsedTime=0;     //tiempo que ha pasado, para la desaparición
    private Color transparencia;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Life_Component>())
        {
            InicioCuentra = true;
        }
    }
    private void Update()
    {
        if (InicioCuentra == true)
        {
            _elapsedTime += Time.deltaTime;
            transparencia.a = Mathf.Lerp(1, 0, _elapsedTime/cont);
            GetComponent<SpriteRenderer>().color = transparencia;
            if (_elapsedTime >= cont)
            {
                InicioCuentra = false; 
                gameObject.SetActive(false);
            }
        }
        else
        {
            transparencia.a = 1;
            GetComponent<SpriteRenderer>().color = transparencia;
            _elapsedTime = 0;
        }
    }
    private void Start()
    {
        transparencia = GetComponent<SpriteRenderer>().color;
    }

}
