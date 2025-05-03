using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class StackBaseUI : MonoBehaviour
{
    protected StackUIManager uiManager;

    public virtual void Init(StackUIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract StackUIState GetStackUIState();
    
    public void SetActive(StackUIState state)
    {
        gameObject.SetActive(GetStackUIState() == state);
    }

}
