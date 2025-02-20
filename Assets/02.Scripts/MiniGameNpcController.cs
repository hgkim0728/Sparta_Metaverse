using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameNpcController : MonoBehaviour
{
    [SerializeField] private GameObject miniGamePanel;
    [SerializeField] private Text textBestScore;
    [SerializeField] private int miniGameNum = 0;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SetMiniGamePanel();
        }
    }

    private void SetMiniGamePanel()
    {
        gameManager.PausePlayer();
        miniGamePanel.SetActive(true);
        // 시작 버튼에 미니게임 시작 함수 연결해주기
        miniGamePanel.transform.GetChild(0).Find("ExitBtn").GetComponent<Button>().onClick.AddListener(SleepPanel);
        miniGamePanel.SetActive(false);
        // 미니 게임 정보를 받아와 최고 점수 표시
    }

    private void SleepPanel()
    {
        miniGamePanel.SetActive(false);
        gameManager.PausePlayer();
    }

    private void LoadMiniGameScene()
    {
        gameManager.SavePlayerInfo(miniGameNum);
    }
}
