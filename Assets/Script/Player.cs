using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _speed;//�ړ��X�s�[�h

    public float jumpForce; // �W�����v�̗�
    public float maxJumpTime; // �W�����v�̍ő厝������

    private bool isJumping = false; // �W�����v�����ǂ����̃t���O
    private float jumpTime = 0f; // �W�����v�̌o�ߎ���
     

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

        // �W�����v���̏ꍇ
        if (isJumping)
        {
            // �W�����v�̌o�ߎ��Ԃ��v��
            jumpTime += Time.deltaTime;

            // �W�����v�̍ő厝�����Ԃ𒴂����ꍇ�̓W�����v�I��
            if (jumpTime >= maxJumpTime)
            {
                isJumping = false;
                transform.position += Vector3.down * jumpForce;
            }
        }

    }
}
