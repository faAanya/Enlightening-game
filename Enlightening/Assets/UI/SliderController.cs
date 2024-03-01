using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health;

        slider.value = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health;


    }

}
