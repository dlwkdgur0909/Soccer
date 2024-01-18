using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Vector3 Player1Pos; //x, y, z
    private Vector3 Player2Pos;
    private Vector3 BallPos;

    public GameObject Goal;
    Rigidbody2D rb;
    public float forceAmount = 1f;

    public bool isPlayer1 = false;
    public bool isPlayer2 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player1Pos = new Vector3(-4, -2,0);
        Player2Pos = new Vector3(4, -2, 0);
        BallPos = new Vector3(0, 1.5f, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.CompareTag("Player1"))
        {
            isPlayer1 = true;
            Vector2 awayDirection = (transform.position - coll.transform.position).normalized;
            rb.AddForce(awayDirection * forceAmount, ForceMode2D.Impulse);
        }

        if (coll.gameObject.CompareTag("Player2"))
        {
            isPlayer2 = true;
            Vector2 awayDirection = (transform.position - coll.transform.position).normalized;
            rb.AddForce(awayDirection * forceAmount, ForceMode2D.Impulse);
        }

        if (coll.gameObject.CompareTag("GoalPost2"))
        {
            GameManager.Instance.Player1AddScore(1);
            StartCoroutine(ActivateUI());
            PosInit();

        }
        else if (coll.gameObject.CompareTag("GoalPost1"))
        {
            GameManager.Instance.Player2AddScore(1);
            StartCoroutine(ActivateUI());
            PosInit();
        }
    }

    public IEnumerator ActivateUI()
    {
        Goal.SetActive(true); // UI 활성화

        yield return new WaitForSeconds(0.8f); // 2초 대기

        Goal.SetActive(false); // UI 비활성화
    }

    void PosInit()
    {
        GameManager.Instance.player[0].position = Player1Pos;
        GameManager.Instance.player[1].position = Player2Pos;

        transform.position = BallPos;
        rb.velocity = Vector2.zero;
    }

}
