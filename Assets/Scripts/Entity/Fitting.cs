using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Fitting : MonoBehaviour
{
    public GameObject fittingUI;
    private bool isRange = false;

      void Start()
    {
       
    }


    void Update()
    {
        if (isRange && Input.GetKeyDown(KeyCode.F))
        {
            if(fittingUI.activeSelf)
            {
                fittingUI.SetActive(false);
            }
            else
            {
                fittingUI.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        fittingUI.SetActive(false);
        isRange = false;
    }
}
