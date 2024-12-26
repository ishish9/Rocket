using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    private Slider slider;
    public float slidervalue;
    private float fuelLVL = 100f;

    void Start()
    {
        slider = GetComponent<Slider>();
        //slider.maxValue = fuelLVL;
        //SetFuelLevel(fuelLVL);
    }

    private void OnEnable()
    {
        FuelUpContainer.OnFuelup += AddFuel;
    }

    private void OnDisable()
    {
        FuelUpContainer.OnFuelup -= AddFuel;
    }

     public void SetFuelLevel(float slidervalue)
    {
        slider.value = slidervalue;
    }

    public void AddFuel(float newValue)
    {
        slider.value += slidervalue + newValue;
    }

}
