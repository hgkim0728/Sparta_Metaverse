using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameNpcController : MonoBehaviour
{
    [SerializeField] private GameObject miniGamePanel;
    [SerializeField] private Text textBestScore;
    [SerializeField] private int miniGameSceneNum = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControlller>().IsPlay = false;
            SetMiniGamePanel();
        }
    }

    private void SetMiniGamePanel()
    {
        miniGamePanel.SetActive(true);
        // 미니 게임 정보를 받아와 최고 점수 표시
    }
}
