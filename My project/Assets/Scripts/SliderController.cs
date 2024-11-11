using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class SliderController : MonoBehaviour
{
    
    public TextMeshProUGUI textMeshProUGUI = null;
    private int maxslidervalue = 100;
    
    void Changevalue(int value)
    {
        Slider slider=transform.GetComponent<Slider>();
        slider.value = value * maxslidervalue;
        textMeshProUGUI.text = value.ToString("0");
    }

    
      
}
