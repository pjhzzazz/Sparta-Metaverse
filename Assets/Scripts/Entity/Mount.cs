using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mount : MonoBehaviour
{
    public GameObject player;
    private bool isRange;
    private bool isMounted = false;

    public GameObject keyUI;

    [SerializeField] private float mountSpeed = 10f;

    public Animator animator;
    void Start()
    {
        if(isMounted == false)
        {

            animator.enabled = false;
        }
    }

    
    void Update()
    {
        if(isRange && Input.GetKeyDown(KeyCode.F))
        {
            BaseController player = FindObjectOfType<BaseController>();
            player.Mount(this, isMounted);
            isMounted = !isMounted;
        }

        if (isMounted == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.7f);
            animator.enabled = true;

            keyUI.SetActive(false);
        }

        animator.enabled = isMounted;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isRange = true;
            keyUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRange = false;
            keyUI.SetActive(false);
        }
    }

    public float GetMountSpeed()
    {
        return mountSpeed;
    }
}
