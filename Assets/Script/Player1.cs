using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jumpPower = 5f;
    public int jumpCount = 0;
    public float moveSpeed = 5f;
    public float chargeTime = 0f;
    public float maxChargeTime = 2f;
    public float curChargeTime = 0f;
    [SerializeField] private bool isCharge = false;



    bool isRotating = false;
    float rotationDuration = 0.5f;

    private Vector2 inputVec = Vector2.zero;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //이동
        if (Input.GetKey(KeyCode.A)) inputVec.x = -1;
        else if (Input.GetKeyUp(KeyCode.A)) inputVec.x = 0;

        if (Input.GetKey(KeyCode.D)) inputVec.x = +1;
        else if (Input.GetKeyUp(KeyCode.D)) inputVec.x = 0;


        Jump();
        //Rorate();
        ShootCharging();
    }

    private void FixedUpdate()
    {
        Vector2 dirVec = inputVec * moveSpeed;
        rigid.velocity = new Vector2(dirVec.x, rigid.velocity.y);
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumpCount >= 1)
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

    void Rorate()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isRotating)
        {
            isRotating = true;

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
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
            yield return null;
        }

        isRotating = false;
    }

    void ShootCharging()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isCharge = true;
            curChargeTime += Time.deltaTime;
            moveSpeed = 3f;
            curChargeTime = Mathf.Min(curChargeTime, maxChargeTime); //최대 차징 시간을 넘지 않도록 제한
        }

        else if (isCharge)
        {
            StartCoroutine(RotatePlayer());
            isCharge = false;
            curChargeTime = 0f;
        } 

        if(Input.GetKeyUp(KeyCode.S))
        {
            isCharge = false;
            moveSpeed = 10f;
        }
    }
}