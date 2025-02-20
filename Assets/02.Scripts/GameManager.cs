using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    class PlayerInfo
    {
        public Vector2 pos = Vector2.zero;
    }

    public static GameManager Instance;
    private static PlayerInfo playerInfo;

    [SerializeField] MiniGameNpcController[] miniGames;

    PlayerControlller player;

    int[] bestScores;

    private readonly string flappyBestScoreKey = "FlappyBestScore";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(Instance != this)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        player = GameManager.FindObjectOfType<PlayerControlller>();
        bestScores = new int[miniGames.Length];

        // 미니게임을 더 추가하게 되면 그때 수정
        bestScores[0] = PlayerPrefs.HasKey(flappyBestScoreKey) ? PlayerPrefs.GetInt(flappyBestScoreKey) : 0;
    }

    public void PausePlayer()
    {
        player.ChangeIsPlay();
    }

    public void SavePlayerInfo(int _miniGameNum)
    {
        //playerInfo.pos = player.transform.position;
        SceneManager.LoadScene(_miniGameNum);
    }

    public int UpdateBestScore(int _score)
    {
        if(PlayerPrefs.HasKey(flappyBestScoreKey))
        {
            if(_score < bestScores[0])
            {
                return bestScores[0];
            }
        }

        PlayerPrefs.SetInt(flappyBestScoreKey, _score);
        bestScores[0] = _score;

        return _score;
    }

    public void ReturnMainScene()
    {
        SceneManager.LoadScene("Main");
        //player.LoadPlayerInfo(playerInfo.pos);
    }

    public int SendBestScore(int miniGameIdx)
    {
        if (PlayerPrefs.HasKey(flappyBestScoreKey))
        {
            return bestScores[miniGameIdx - 1];
        }
        else
        {
            return 0;
        }
    }
}
