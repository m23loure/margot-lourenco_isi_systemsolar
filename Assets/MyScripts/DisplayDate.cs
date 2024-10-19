using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDate : MonoBehaviour
{   public static DisplayDate currentd; 
    public Slider slider; 
    public TextMeshProUGUI slidertext; 
    // Start is called before the first frame update
    private DateTime timeinit= new DateTime(2002,01,20);
    public void Start()
    {
       slidertext.text = timeinit.ToString();
       
        //Debug.Log(timeinit.ToString());
        //Debug.Log(slidertext.text);
    }

    // Update is called once per frame
    public void Update()
    {
       
        slidertext.text = PlanetManager.current.DateForText(); 
    }
}
