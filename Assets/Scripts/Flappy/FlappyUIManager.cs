using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private int bestScore;

    private void Awake()
    {
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
        gameUI.SetUI(GameManager.Instance.currentScore);

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public void OnClickStartGame()
    {
        Time.timeScale = 1f;

        FindObjectOfType<Plane>().StartGame(); 

        ChangeState(FlappyUIState.Game);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(GameManager.Instance.currentScore, bestScore);
        ChangeState(FlappyUIState.Score);
    }

    internal void OnClickExit()
    {
        SceneManager.LoadScene("MainScene");
    }
}
