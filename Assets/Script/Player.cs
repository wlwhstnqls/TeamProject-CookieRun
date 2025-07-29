using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;
    CircleCollider2D circleCollider = null;

    public float speed = 5f;
    public bool isDead = false;
    public float jumpForce = 8f;
    public bool isJumping = false;
    public bool isGrounded = false;

    int JumpCount = 0;
    int MaxJumpCount = 2;


    void Start()
    {
        Camera.main.GetComponent<FollowCamera>().player = transform;
        animator =transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isJumping = true;

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetMouseButton(1))
        {
            animator.SetBool("Isground", true);
            animator.SetBool("IsWalk", false);
        }
        else
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("Isground", false);
        }

        isGrounded = Physics2D.OverlapCircle(transform.position, 0.64f, LayerMask.GetMask("Ground"));
        Vector2 velocity = rb.velocity;
        velocity.x = speed;
        if (isGrounded)
        {
            JumpCount = 0;
        }

        if (isJumping && JumpCount < MaxJumpCount)
        {
            velocity.y += jumpForce;
            isJumping = false;
            JumpCount++;

        }

      
        Debug.Log("Is Grounded: " + isGrounded);
        Debug.Log("Jump Count: " + JumpCount);
        Debug.Log("Is Jumping: " + isJumping);
        Debug.Log(JumpCount < MaxJumpCount);

        rb.velocity = velocity;

        float angle = Mathf.Clamp((rb.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void FixedUpdate()
    {
      
        

        
      

    }

    
}
