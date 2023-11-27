using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Controls : MonoBehaviour
{
    [SerializeField] private GameObject boosterMain;
    [SerializeField] private GameObject booster1;
    [SerializeField] private GameObject booster2;
    [SerializeField] private GameObject booster3;
    [SerializeField] private GameObject booster4;
    [SerializeField] private GameObject boostersnd;
    [SerializeField] private GameObject Thrustersnd1;
    [SerializeField] private GameObject Thrustersnd2;
    [SerializeField] private GameObject ThrusterR;
    [SerializeField] private GameObject ThrusterL;
    [SerializeField] private GameObject ThrusterOFF1;
    [SerializeField] private GameObject ThrusterOFF2;
    [SerializeField] private GameObject ThrusterOFF3;

    public float speed;
    public float acceleration = 1.0f;
    private float LeftRightSpeed = 15f;
    private float maxlow = 0;
    private float maxhigh = 300;
    private bool buttonlaunch = false;
    private Rigidbody r;
    public FuelBar fuel;
    private bool isDead = false;
 
    void Start()
    {
        r = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) || buttonlaunch == true)
        {
            if (isDead == false)
            {
            ThrusterOFF1.SetActive(false);
            ThrusterOFF2.SetActive(false);
            ThrusterOFF3.SetActive(false);
            boosterMain.SetActive(true);
            booster1.SetActive(true);
            booster2.SetActive(true);
            booster3.SetActive(true);
            booster4.SetActive(true);
            boostersnd.SetActive(true);
            r.AddForce(Vector3.up * speed);
            speed += acceleration;
            fuel.slidervalue -= Time.deltaTime;
            fuel.SetFuelLevel(fuel.slidervalue);
            if (speed >= maxhigh)
            {
                speed = maxhigh;
            }

            if (fuel.slidervalue <= 0)
            {
                isDead = true;
                    ThrusterOFF1.SetActive(true);
                    ThrusterOFF2.SetActive(true);
                    ThrusterOFF3.SetActive(true);
                }
            }
            else
            {
                
                boosterMain.SetActive(false);
                booster1.SetActive(false);
                booster2.SetActive(false);
                booster3.SetActive(false);
                booster4.SetActive(false);
                boostersnd.SetActive(false);
                speed -= acceleration;
                if (speed <= maxlow)
                {
                    speed = maxlow;
                }
            }
        }
        else
        {
            ThrusterOFF1.SetActive(true);
            ThrusterOFF2.SetActive(true);
            ThrusterOFF3.SetActive(true);
            boosterMain.SetActive(false);
            booster1.SetActive(false);
            booster2.SetActive(false);
            booster3.SetActive(false);
            booster4.SetActive(false);
            boostersnd.SetActive(false);
            speed -= acceleration;
            if (speed <= maxlow)
            {
                speed = maxlow;
            }
              
        }
        /////Left Right Controls
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            r.AddForce(-LeftRightSpeed, 0, 0, ForceMode.Force);
            ThrusterR.SetActive(true);
            Thrustersnd1.SetActive(true);
        }
        else
        {
            ThrusterR.SetActive(false);
            Thrustersnd1.SetActive(false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            r.AddForce( LeftRightSpeed, 0, 0, ForceMode.Force);
            ThrusterL.SetActive(true);
            Thrustersnd2.SetActive(true);
        }
        else
        {
            ThrusterL.SetActive(false);
            Thrustersnd2.SetActive(false);
        }
    }

    public void thruston()
    {
        buttonlaunch = true;
    }

    public void thrustoff()
    {
        buttonlaunch = false;
    }
}
