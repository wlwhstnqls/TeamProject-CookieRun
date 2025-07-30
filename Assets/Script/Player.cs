using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    float time = 0f;

    int JumpCount = 0;
    int MaxJumpCount = 2;


    void Start()
    {
        Camera.main.GetComponent<FollowCamera>().player = transform;
        animator =transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (JumpCount == MaxJumpCount)
                return;
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
        time += Time.deltaTime;

        if (time >= 10.0f)
        { 
            speed += 1f;
            time = 0f;
            return;
        }

    }
    public void FixedUpdate()
    {
        if (IsGrounded())
        {
            JumpCount = 0;
        }

        Vector2 velocity = rb.velocity;
        velocity.x = speed;

        if (isJumping && JumpCount < MaxJumpCount)
        {
            velocity.y += jumpForce;
            JumpCount++;
            isJumping = false;
        }
        Debug.Log("JumpCount: " + JumpCount);
        rb.velocity = velocity;

        float angle = Mathf.Clamp((rb.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
           
    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position,0.64f, LayerMask.GetMask("Ground"));
    }  

    
}
