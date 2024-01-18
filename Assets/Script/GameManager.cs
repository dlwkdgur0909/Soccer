using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform[] player;

    public Text P1Score;
    public Text P2Score;

    public int Player1Score;
    public int Player2Score;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void Player1AddScore(int num)
    {
        Player1Score++;
        P1Score.text = Player1Score.ToString();
    }

    public void Player2AddScore(int num1)
    {
        Player2Score++;
        P2Score.text = Player2Score.ToString();
    }
}
