using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;
    
    FlappyUIManager uiManager;

    public FlappyUIManager UIManager { get { return uiManager; } }


    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<FlappyUIManager>();

    }
    

    public void GameOver()
    {
        uiManager.SetRestart();
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);

    }
    void Start()
    {
        uiManager.UpdateScore(0);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

