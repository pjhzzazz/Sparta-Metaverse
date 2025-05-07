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
    public Plane plane;

    public int currentScore = 0;

    public GameObject[] CountsUI;
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

        UpdateScore(0);
    }

    public void ChangeState(FlappyUIState newState)
    {
        if (currentState == newState) return;
        currentState = newState;

        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);

        Debug.Log($" - homeUI activeSelf: {homeUI?.gameObject.activeSelf}");
        Debug.Log($" - gameUI activeSelf: {gameUI?.gameObject.activeSelf}");
        Debug.Log($" - scoreUI activeSelf: {scoreUI?.gameObject.activeSelf}");

    }

    public void UpdateScore(int score)
    {
        gameUI.SetUI(currentScore);

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public void OnClickStartGame()
    {
        ChangeState(FlappyUIState.Game);
        StartCoroutine(Count());
        plane.StartGame();
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(currentScore, bestScore);
        ChangeState(FlappyUIState.Score);
    }

    internal void OnClickExit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScore(currentScore);

    }
    IEnumerator Count()
    {
        for (int i = 0; i < CountsUI.Length; i++)
        {
            CountsUI[i].SetActive(true);
            yield return new WaitForSecondsRealtime(1);
            CountsUI[i].SetActive(false);
        }
        Time.timeScale = 1f;
    }
}
