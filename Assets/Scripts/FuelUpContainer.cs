using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUpContainer : MonoBehaviour
{
    [SerializeField] private AudioSource fuelCollectSound;
    [SerializeField] private ParticleSystem FuelCollectedEffect;
    [SerializeField] private Transform FuelCollectedEffectPosition;
    [SerializeField] private FuelBar script;

    private void OnTriggerEnter()
    {
        fuelCollectSound.Play();
        gameObject.SetActive(false);
        FuelCollectedEffectPosition.position = transform.position;
        FuelCollectedEffect.Play();
        script.slidervalue += 5f;
    }
}
