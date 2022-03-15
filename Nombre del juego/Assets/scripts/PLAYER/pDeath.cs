using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pDeath : MonoBehaviour
{
    [SerializeField]
    private float lifetime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Sprite[] explosion;
    private SpriteRenderer render;
    [SerializeField]
    private GameObject playerR;
    [SerializeField]
    private Sprite playerDeath;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private float Progression = 0;
    private int i = 0;
    private void DeathAnim()
    {
        if (Progression < 1)
        {
            Progression += Time.deltaTime * speed;
            if (i == explosion.Length)
            {
                i = 0;
            }
            render.sprite = explosion[i];
        }
        else if (Progression >= 1)
        {
            i++;
            Progression = 0;
        }
        playerR.GetComponent<SpriteRenderer>().sprite = playerDeath;
    }

    private float prog = 0;
    void Update()
    {
        if (prog >= lifetime)
        {
            Destroy(gameObject);
        }
        else
        {
            DeathAnim();
            prog += Time.deltaTime;
        }
    }
}
