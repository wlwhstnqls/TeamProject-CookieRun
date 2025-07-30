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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       
        time += Time.deltaTime;
        if (time >= 3.0f)
        {
            isJumping = true;
            if(isJumping == true)
            {
                animator.SetBool("IsJump", true);
            }
            else
            {
                animator.SetBool("IsJump", false);
            }
            time = 0f;
            return;
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
