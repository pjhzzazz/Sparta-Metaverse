using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyGameUI : FlappyBaseUI
{

    TextMeshProUGUI scoreText;

    protected override FlappyUIState GetFlappyUIState()
    {
        return FlappyUIState.Game;
    }

    public override void Init(FlappyUIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
       
    }


    public void SetUI(int score)
    {
        scoreText.text = score.ToString();

    }
}
