using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int multiplier = 1;
    private Rigidbody2D rb;
    private float _lifeTime=0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private float pOffset = 0.4f;
    public void Destruir()
    {
        gameObject.SetActive(false);        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement.pInstance.pTransform.position = transform.position + new Vector3(0, pOffset, 0);
        PlayerMovement.pInstance._myRigidBody.velocity = new Vector2(0, 0);
        Destroy(gameObject);
    }
        
    void Update()
    {
        _lifeTime += Time.deltaTime;
        if (_lifeTime >= 8)
        {
            Destroy(gameObject);
        }
        //rotacion de la flecha
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
