using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_BarraTensado : MonoBehaviour
{
    [SerializeField]
    public Slider Slider;
    [SerializeField]
    public Image Image;
    // Start is called before the first frame update
    public void AjustarDimensiones(float percent)
    {
        Slider.value = percent;
    }
    public void AjustarMaximo(float max)
    {
        Slider.maxValue = max;
    }
    public void AjustarColor(bool attack)
    {
        if(attack) Image.color = Color.yellow;
        else Image.color = Color.cyan;
    }
}
