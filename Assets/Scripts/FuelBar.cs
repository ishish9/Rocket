using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider slider;
    public float slidervalue;
    private float fuelLVL = 30f;

    void Start()
    {
        slider.maxValue = fuelLVL;
        SetFuelLevel(fuelLVL);
    }

    public void SetFuelLevel(float slidervalue)
    {
        slider.value = slidervalue;
    }
}
