using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gostController : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer ghost;
    private Transform gTransform;
    [SerializeField]
    private GameObject pReference;
    void Start()
    {
        gTransform = transform;
        ghost = GetComponent<SpriteRenderer>();
        if (PlayerMovement.pInstance.pIsLookingRight)
        {
            gTransform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            gTransform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private float dissapear = 0.7f;
    [SerializeField]
    private float dissapearSpeed;
    void Update()
    {
        dissapear -= Time.deltaTime * dissapearSpeed;
        if (dissapear <= 0)
        {
            Destroy(gameObject);
        }
        //ghost.sprite = pReference.GetComponent<SpriteRenderer>().sprite;
        ghost.color = new Color(1, 1, 1, dissapear);
    }
}
