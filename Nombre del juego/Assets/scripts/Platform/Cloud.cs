using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    bool InicioCuentra = false;
    [SerializeField]
    public float cont;
    private float _elapsedTime=0;     //tiempo que ha pasado, para la desaparición
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
            if (_elapsedTime >= cont)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
