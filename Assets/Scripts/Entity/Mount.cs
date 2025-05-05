using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mount : MonoBehaviour
{
    public GameObject player;
    private bool isRange;
    private bool isMounted = false;

    [SerializeField] private float mountSpeed = 10f;

   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(isRange && Input.GetKeyDown(KeyCode.F))
        {
            BaseController player = FindObjectOfType<BaseController>();
            player.Mount(this, isMounted);
            isMounted = !isMounted;
        }
        
        if(isMounted)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.7f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRange = false;
        }
    }

    public float GetMountSpeed()
    {
        return mountSpeed;
    }
}
