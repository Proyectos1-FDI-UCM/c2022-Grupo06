using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow2 : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    public int multiplier=2;
    [SerializeField]
    private int Damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Instance.Play("Disparo");
        if (collision.gameObject.GetComponent<CameraFollow>()==false)
        {
            Destroy(this.gameObject);//se elimina la bala al chocar con lo que sea
            if (collision.gameObject.GetComponent<Enemy_Life_Component>())//si es con el enemigo se le hace da�o
            {
                //Debug.Log("entramos en el trigger");
                GameManager.Instance.EnemyDamage(Damage, collision.gameObject);
            }
        }
      


    }
    void Update()
    {
        //rotacion de la flecha
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
