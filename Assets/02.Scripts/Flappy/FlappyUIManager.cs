using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyUIManager : MonoBehaviour
{
    [SerializeField] private GameObject guidePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text resultText;

    private void Start()
    {
        if(Time.timeScale != 0)
            guidePanel.SetActive(false);
    }

    public void SetRestart(int _bestScore)
    {
        gameOverPanel.SetActive(true);
        resultText.text = "BestScore : " + _bestScore.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void FlapStart()
    {
        guidePanel.SetActive(false);
        GameManager.Instance.MiniGameStart();
    }
}
