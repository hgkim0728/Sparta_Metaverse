using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyManager : MonoBehaviour
{
    public static FlappyManager FlappyInstance;

    private int currentScore = 0;

    FlappyUIManager uiManager;
    public FlappyUIManager UIManager { get { return uiManager; } }

    GameManager gameManager;

    private void Awake()
    {
        if( FlappyInstance == null )
        {
            FlappyInstance = this;
        }

        uiManager = FindObjectOfType<FlappyUIManager>();
        gameManager = GameManager.Instance;
    }

    public void GameOver()
    {
        int bestScore =  gameManager.UpdateBestScore(currentScore);
        uiManager.SetRestart(bestScore);
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

    public void ExitGame()
    {
        gameManager.ReturnMainScene();
    }
}
