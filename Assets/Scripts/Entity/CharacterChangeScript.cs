using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangeScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] CharacterSprites;

    public Animator animatior;
    public RuntimeAnimatorController[] contorllers;

    public GameObject fittingUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeCharacter(int index)
    {
        if (index >= 0 && index < CharacterSprites.Length)
        {
            spriteRenderer.sprite = CharacterSprites[index];
        }

        animatior.runtimeAnimatorController = contorllers[index];

        fittingUI.SetActive(false);
    }
}
