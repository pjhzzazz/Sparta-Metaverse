using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class FlappyBaseUI : MonoBehaviour
{
    protected FlappyUIManager uiManager;

    public virtual void Init(FlappyUIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract FlappyUIState GetFlappyUIState();
    
    public void SetActive(FlappyUIState state)
    {
        gameObject.SetActive(GetFlappyUIState() == state);
    }

}

