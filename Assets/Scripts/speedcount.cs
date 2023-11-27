using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class speedcount : MonoBehaviour
{
    [SerializeField] private Rocket_Controls script;
    public GameObject speed_text;
    private TextMeshProUGUI speedt;

    void Start()
    {
        speedt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //speed_text.GetComponent<Text>().text = script.speed.ToString();
        speedt.text = script.speed.ToString();
    }
}
