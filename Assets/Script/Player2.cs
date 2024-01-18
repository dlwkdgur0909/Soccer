using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jumpPower = 5f;
    public int jumpCount = 0;
    public float moveSpeed = 5f;


    bool isRotating = false;
    float rotationDuration = 0.5f;

    private Vector2 inputVec = Vector2.zero;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //ÀÌµ¿
        if (Input.GetKey(KeyCode.LeftArrow)) inputVec.x = -1;
        else if (Input.GetKeyUp(KeyCode.LeftArrow)) inputVec.x = 0;

        if (Input.GetKey(KeyCode.RightArrow)) inputVec.x = +1;
        else if (Input.GetKeyUp(KeyCode.RightArrow)) inputVec.x = 0;


        Jump();
        RotateOnKeyPress();
    }

    private void FixedUpdate()
    {
        Vector2 dirVec = inputVec * moveSpeed;
        rigid.velocity = new Vector2(dirVec.x, rigid.velocity.y);
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount >= 1)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" && jumpCount == 0)
        {
            jumpCount++;
        }
    }

    void RotateOnKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isRotating)
        {
            isRotating = true;
            StartCoroutine(RotatePlayer());
        }
    }

    IEnumerator RotatePlayer()
    {
        float startRotation = transform.rotation.eulerAngles.z;
        float endRotation = startRotation + 360f;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / rotationDuration;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t);
            transform.rotation = Quaternion.Euler(0f, 0f, -zRotation);
            yield return null;
        }

        isRotating = false;
    }
}