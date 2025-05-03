using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyHomeUI : FlappyBaseUI
{
    Button startButton;
    Button exitButton;
    protected override FlappyUIState GetFlappyUIState()
    {
        return FlappyUIState.Home;
    }

    public override void Init(FlappyUIManager uiManager)
    {
        base.Init(uiManager);

        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStartGame();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }

}

