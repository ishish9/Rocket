using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rocket_Controls : MonoBehaviour
{
    InputSystem_Actions inputMap;
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
    private Vector2 move;
    public delegate void fuelLevel();
    public static event fuelLevel OnFuel;

    public float speed;
    public float acceleration = 1.0f;
    private float LeftRightSpeed = 15f;
    private float miniSpeed = 0;
    private float maxSpeed = 300;
    private Rigidbody rigidBody;
    public FuelBar fuel;
    private bool buttonlaunch = false;
    private bool isDead = false;

    private void Awake()
    {
        inputMap = new InputSystem_Actions();
       // inputMap.Player.Thrust.performed += OnThrustEnable;
        inputMap.Player.Jump.performed += OnMoveRocket;

    }

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputMap.Player.Enable();

    }

    private void OnDisable()
    {
        inputMap.Player.Disable();

    }

    private void Update()
    {
        move = inputMap.Player.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (inputMap.Player.Thrust.triggered == true|| buttonlaunch == true)
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
            rigidBody.AddForce(Vector3.up * speed);
            speed += acceleration;
            fuel.slidervalue -= Time.deltaTime;
            fuel.SetFuelLevel(fuel.slidervalue);
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
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
                if (speed <= miniSpeed)
                {
                    speed = miniSpeed;
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
            if (speed <= miniSpeed)
            {
                speed = miniSpeed;
            }
              
        }
        /////Left Right Controls
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(-LeftRightSpeed, 0, 0, ForceMode.Force);
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
            rigidBody.AddForce( LeftRightSpeed, 0, 0, ForceMode.Force);
            ThrusterL.SetActive(true);
            Thrustersnd2.SetActive(true);
        }
        else
        {
            ThrusterL.SetActive(false);
            Thrustersnd2.SetActive(false);
        }
    }

    

    public void OnMoveRocket(InputAction.CallbackContext contex)
    {
                /////Left Right Controls
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rigidBody.AddForce(-LeftRightSpeed, 0, 0, ForceMode.Force);
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
                    rigidBody.AddForce(LeftRightSpeed, 0, 0, ForceMode.Force);
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

    public void thrustToggle()
    {
        buttonlaunch = !buttonlaunch;
    }
}
