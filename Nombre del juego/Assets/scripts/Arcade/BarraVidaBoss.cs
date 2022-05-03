using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject Boss;
    public Slider slider;
    // Start is called before the first frame update

    private void Start()
    {
        slider.maxValue = Boss.GetComponent<Enemy_Life_Component>()._maxlife;
    }

    private void Update()
    {
        slider.value = Boss.GetComponent<Enemy_Life_Component>()._currentlife;
    }
}
