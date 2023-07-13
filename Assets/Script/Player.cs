using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _speed;//移動スピード

    public float jumpForce; // ジャンプの力
    public float maxJumpTime; // ジャンプの最大持続時間

    private bool isJumping = false; // ジャンプ中かどうかのフラグ
    private float jumpTime = 0f; // ジャンプの経過時間
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float z = Input.GetAxis("Horizontal");
        this.transform.position += new Vector3(z, 0, 0) * Time.deltaTime * _speed;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpTime = 0f;


            transform.position += Vector3.up * jumpForce;
        }

        // ジャンプ中の場合
        if (isJumping)
        {
            // ジャンプの経過時間を計測
            jumpTime += Time.deltaTime;

            // ジャンプの最大持続時間を超えた場合はジャンプ終了
            if (jumpTime >= maxJumpTime)
            {
                isJumping = false;
                transform.position += Vector3.down * jumpForce;
            }
        }

    }
}
