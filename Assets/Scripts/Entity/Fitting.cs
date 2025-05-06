using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Fitting : MonoBehaviour
{
    public GameObject fittingUI;
    public GameObject mountUI;
    private bool isRange = false;

    public GameObject keyUI;
    public GameObject TextUI;

    public TextMeshProUGUI[] textMeshProUGUIs;


      void Start()
    {
       
    }


    void Update()
    {
        if (isRange && Input.GetKeyDown(KeyCode.Tab))
        {
            TextUI.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRange = true;
            keyUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        fittingUI.SetActive(false);
        mountUI.SetActive(false);
        isRange = false;
        keyUI.SetActive(false);
    }


    public void ShowCharacter()
    {
        fittingUI.SetActive(true);
        TextUI.SetActive(false);
    }

    public void ShowVehicle()
    {
        mountUI.SetActive(true);
        TextUI.SetActive(false);
    }
}
