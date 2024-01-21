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
        if (Instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            Instance = this; //���ڽ��� instance�� �־��ݴϴ�.
        }
        else
        {
            if (Instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
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
