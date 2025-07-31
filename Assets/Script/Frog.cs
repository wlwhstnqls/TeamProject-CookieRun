using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;
    BoxCollider2D boxCollider = null;

    public float jumpForce = 4f;
    public bool isJumping = false;
    float time = 0f;
    float RandomJump = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Time.timeScale = 1f;
        RandomJump = Random.Range(1.0f, 3.0f); // 1초에서 3초 사이의 랜덤 시간 설정
    }

    // Update is called once per frame
    void Update()
    {
       
        time += Time.deltaTime;
        if (time >= RandomJump)
        {
            isJumping = true;
                      
            animator.SetTrigger("JumpTrig");
                          
                         
            time = 0f;
                        
            return;
        }
        else
        {
            animator.SetTrigger("IdleTrig");
        }

            Vector2 velocity = rb.velocity;

        if (isJumping == true)
        {
            velocity.y += jumpForce;
            isJumping = false;
        }
        
        rb.velocity = velocity;
    }
            


}
