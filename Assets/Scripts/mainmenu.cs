using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private AudioSource Music;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.gameObject.SetActive(true);
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
