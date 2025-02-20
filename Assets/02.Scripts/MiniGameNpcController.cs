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
        miniGamePanel.SetActive(true);
        if (miniGamePanel.activeSelf == false) return;
        gameManager.PausePlayer();
        // ���� ��ư�� �̴ϰ��� ���� �Լ� �������ֱ�
        miniGamePanel.transform.GetChild(0).Find("StartBtn").GetComponent<Button>().onClick.AddListener(LoadMiniGameScene);
        miniGamePanel.transform.GetChild(0).Find("ExitBtn").GetComponent<Button>().onClick.AddListener(SleepPanel);
        // �̴� ���� ������ �޾ƿ� �ְ� ���� ǥ��
        textBestScore.text = gameManager.SendBestScore(miniGameNum).ToString();
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
