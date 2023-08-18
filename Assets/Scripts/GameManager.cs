using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private int coin = 0;
    [SerializeField] private TextMeshProUGUI text = null;

    [HideInInspector]
    public bool isGameOver = false;

    [SerializeField] private GameObject gameoverUI = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// 코인을 증가시키는 기능
    /// 30 마다 무기 진화
    /// </summary>
    public void IncreaseCoin()
    {
        coin++;
        text.SetText(coin.ToString());
        if (coin % 30 == 0)
        {
            PlayerMove playerMove = FindObjectOfType<PlayerMove>();
            if (playerMove != null)
            {
                playerMove.Upgrade();
            }
        }
    }

    /// <summary>
    /// 게임 오버시 몬스터생성 이 멈추고 1초뒤 게임오버패널 등장기능
    /// </summary>
    public void SetGameOver()
    {
        isGameOver = true;
        
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }
        Invoke("ShowGameOverPanel", 1f);
    }

    /// <summary>
    /// 게임 오버 패널 등장기능
    /// </summary>
    private void ShowGameOverPanel()
    {
        gameoverUI.SetActive(true);
    }

    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
