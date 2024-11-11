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
    public AudioSource bgm;
    public Slider wholev;
    public Slider charv;
    public Slider sfxv;
    public Slider bgmv;

    public void Changevalue(int value)
    {
        int localvalue = value * maxslidervalue;
        textMeshProUGUI.text = localvalue.ToString("0");
        wholev.value = localvalue;
    }



    public void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        wholev =canvas.transform.GetChild(1).GetChild(2).GetComponent<Slider>();
        charv=canvas.transform.GetChild(2).GetChild(2).GetComponent<Slider>();
        sfxv=canvas.transform.GetChild(3).GetChild(2).GetComponent<Slider>();
        bgmv=canvas.transform.GetChild(4).GetChild(2).GetComponent<Slider>();
        bgm=GameObject.Find("BGM").GetComponent<AudioSource>();
        //bgmv.value = bgm.volume;

    }

    public void Update()
    {
        
    }

}
