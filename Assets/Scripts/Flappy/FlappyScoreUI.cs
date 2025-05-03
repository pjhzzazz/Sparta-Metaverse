using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlappyScoreUI : FlappyBaseUI
{

    TextMeshProUGUI scoreText;
    TextMeshProUGUI comboText;
    TextMeshProUGUI bestScoreText;
    TextMeshProUGUI bestComboText;

    Button startButton;
    Button exitButton;

    protected override FlappyUIState GetFlappyUIState()
    {
        return FlappyUIState.Score;
    }

    public override void Init(FlappyUIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();

        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void SetUI(int score, int combo, int bestScore, int bestCombo)
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
        bestScoreText.text = bestScore.ToString();
        bestComboText.text = bestCombo.ToString();
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
