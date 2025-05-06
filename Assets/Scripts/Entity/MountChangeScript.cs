using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountChangeScript : MonoBehaviour
{
    public SpriteRenderer ChangeMountColors;
    public Sprite[] Colors;

    public Animator animator;
    public RuntimeAnimatorController[] contorllers;

    public GameObject MountUI;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void MountChange(int index)
    {
        ChangeMountColors.sprite = Colors[index];
        animator.runtimeAnimatorController = contorllers[index];

        MountUI.SetActive(false);
    }
}
