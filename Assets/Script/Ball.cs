using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Vector3 Player1Pos;
    private Vector3 Player2Pos;
    private Vector3 BallPos;

    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    public GameObject goalPost1;
    public GameObject goalPost2;
    public GameObject Goal;

    Rigidbody2D rb;
    public float forceAmount = 1f;

    public bool isPlayer1 = false;
    public bool isPlayer2 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player1Pos = new Vector3(-4, -2, 0);
        Player2Pos = new Vector3(4, -2, 0);
        BallPos = new Vector3(0, 1.5f, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.CompareTag("Player1"))
        {
            isPlayer1 = true;
            isPlayer2 = false;
            Vector2 awayDirection = (transform.position - coll.transform.position).normalized;
            rb.AddForce(awayDirection * forceAmount, ForceMode2D.Impulse);
        }

        if (coll.gameObject.CompareTag("Player2"))
        {
            isPlayer2 = true;
            isPlayer1 = false;
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

    //아이템 먹을 때
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("BigBall"))
        {
            BigBall();
        }

        if (coll.gameObject.CompareTag("SmallBall"))
        {
            SmallBall();
        }

        if (coll.gameObject.CompareTag("BigPlayer") && isPlayer1 == true)
        {
            //플레이어1의 크기가 커짐
            BigPlayer1();
        }
        else if (coll.gameObject.CompareTag("BigPlayer") && isPlayer2 == true)
        {
            //플레이어2의 크기가 커짐
            BigPlayer2();
        }

        if (coll.gameObject.CompareTag("SmallPlayer") && isPlayer1 == true)
        {
            //플레이어2의 크기가 작아짐
            SmallPlayer2();
        }
        else if (coll.gameObject.CompareTag("SmallPlayer") && isPlayer2 == true)
        {
            //플레이어1의 크기가 작아짐
            SmallPlayer1();
        }

        if (coll.gameObject.CompareTag("BigGoalPost") && isPlayer1 == true)
        {
            //플레이어2의 골대가 커짐
            BigGoalPost2();
        }

        else if (coll.gameObject.CompareTag("BigGoalPost") && isPlayer2 == true)
        {
            //플레이어1의 골대가 커짐
            BigGoalPost1();
        }

        if (coll.gameObject.CompareTag("SmallGoalPost") && isPlayer1 == true)
        {
            //플레이어1의 골대가 작아짐
            SmallGoalPost1();
        }

        else if (coll.gameObject.CompareTag("SmallGoalPost") && isPlayer2 == true)
        {
            //플레이어2의 골대가 작아짐
            SmallGoalPost2();
        }
    }

    public void BigPlayer1()
    {
        StartCoroutine(BigPlayer1());
        IEnumerator BigPlayer1()
        {
            player1.transform.localScale = new Vector3(10f, 10f, 10f);

            yield return new WaitForSeconds(5f);

            player1.transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }

    public void BigPlayer2()
    {
        StartCoroutine(BigPlayer2());
        IEnumerator BigPlayer2()
        {
            player2.transform.localScale = new Vector3(10f, 10f, 10f);

            yield return new WaitForSeconds(5f);

            player2.transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }

    public void SmallPlayer2()
    {
        StartCoroutine(SmallPlayer2());
        IEnumerator SmallPlayer2()
        {
            player2.transform.localScale = new Vector3(1f, 1f, 1f);

            yield return new WaitForSeconds(5f);

            player2.transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }

    public void SmallPlayer1()
    {
        StartCoroutine(SmallPlayer1());
        IEnumerator SmallPlayer1()
        {
            player1.transform.localScale = new Vector3(1f, 1f, 1f);

            yield return new WaitForSeconds(5f);

            player1.transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }

    public void BigBall()
    {
        StartCoroutine(BigBall());
        IEnumerator BigBall()
        {
            ball.transform.localScale = new Vector3(5f, 5f, 5f);

            yield return new WaitForSeconds(5f);

            ball.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }

    public void SmallBall()
    {
        StartCoroutine(SmallBall());
        IEnumerator SmallBall()
        {
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            yield return new WaitForSeconds(5f);

            ball.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }

    public void BigGoalPost1()
    {
        StartCoroutine(BigGoalPost1());
        IEnumerator BigGoalPost1()
        {
            goalPost1.transform.localScale = new Vector3(20f, 20f, 20f);
            goalPost1.transform.localPosition = new Vector3(-8.4f, -2.1f, 0f);

            yield return new WaitForSeconds(5f);

            goalPost1.transform.localScale = new Vector3(12f, 12f, 12f);
            goalPost1.transform.localPosition = new Vector3(-8.4f, -3.1f, 0f);
        }
    }

    public void BigGoalPost2()
    {
        StartCoroutine(BigGoalPost2());
        IEnumerator BigGoalPost2()
        {
            goalPost2.transform.localScale = new Vector3(12f, 20f, 0f);
            goalPost2.transform.localPosition = new Vector3(8.4f, -2.1f, 0f);

            yield return new WaitForSeconds(5f);

            goalPost2.transform.localScale = new Vector3(12f, 12f, 12f);
            goalPost2.transform.localPosition = new Vector3(8.4f, -3.1f, 0f);
        }
    }

    public void SmallGoalPost1()
    {
        StartCoroutine(SmallGoalPost1());
        IEnumerator SmallGoalPost1()
        {
            goalPost1.transform.localScale = new Vector3(8f, 8f, 8f);
            goalPost1.transform.localPosition = new Vector3(-8.75f, -3.55f, 0f);

            yield return new WaitForSeconds(5f);

            goalPost1.transform.localScale = new Vector3(12f, 12f, 12f);
            goalPost1.transform.localPosition = new Vector3(-8.4f, -3.1f, 0f);
        }
    }

    public void SmallGoalPost2()
    {
        StartCoroutine(SmallGoalPost2());
        IEnumerator SmallGoalPost2()
        {
            goalPost2.transform.localScale = new Vector3(8f, 8f, 8f);
            goalPost2.transform.localPosition = new Vector3(8.75f, -3.55f, 0f);

            yield return new WaitForSeconds(5f);

            goalPost2.transform.localScale = new Vector3(12f, 12f, 12f);
            goalPost2.transform.localPosition = new Vector3(8.4f, -3.1f, 0f);
        }
    }


    public IEnumerator ActivateUI()
    {
        Goal.SetActive(true);

        yield return new WaitForSeconds(0.8f);

        Goal.SetActive(false);
    }

    void PosInit()
    {
        GameManager.Instance.player1.position = Player1Pos;
        GameManager.Instance.player2.position = Player2Pos;

        transform.position = BallPos;
        rb.velocity = Vector2.zero;
    }
}
