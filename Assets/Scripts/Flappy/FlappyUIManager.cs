using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum FlappyUIState
{
    Home,
    Game,
    Score,
}

public class FlappyUIManager : MonoBehaviour
{
    private FlappyUIState currentState = FlappyUIState.Home;

    private FlappyHomeUI homeUI;
    private FlappyGameUI gameUI;
    private FlappyScoreUI scoreUI;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI restartText;

    private int bestScore;

    private void Awake()
    {
        // UI 오브젝트 찾아서 초기화
        homeUI = GetComponentInChildren<FlappyHomeUI>(true);
        gameUI = GetComponentInChildren<FlappyGameUI>(true);
        scoreUI = GetComponentInChildren<FlappyScoreUI>(true);

        homeUI?.Init(this);
        gameUI?.Init(this);
        scoreUI?.Init(this);

        ChangeState(FlappyUIState.Home);
    }

    private void Start()
    {
        if (scoreText == null) Debug.LogError("scoreText is null");
        if (restartText == null) Debug.LogError("restartText is null");

        restartText?.gameObject.SetActive(false);

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void ChangeState(FlappyUIState newState)
    {
        currentState = newState;

        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString();

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public void SetRestartTextVisible(bool visible)
    {
        if (restartText != null)
            restartText.gameObject.SetActive(visible);
    }

    public void OnClickStartGame()
    {
        ChangeState(FlappyUIState.Game);
    }

    public void OnClickGoHome()
    {
        ChangeState(FlappyUIState.Home);
    }

    public void OnClickShowScore()
    {
        ChangeState(FlappyUIState.Score);
    }

    internal void OnClickExit()
    {
        throw new NotImplementedException();
    }

    internal void SetRestart()
    {
        throw new NotImplementedException();
    }
}
