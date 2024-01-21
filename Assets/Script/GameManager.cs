using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            Instance = this; //내자신을 instance로 넣어줍니다.
        }
        else
        {
            if (Instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }
    public Transform[] player;

    public Text P1Score;
    public Text P2Score;

    public int Player1Score;
    public int Player2Score;

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
