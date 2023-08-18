using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private int coin = 0;
    [SerializeField] private TextMeshProUGUI text = null;
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
}
