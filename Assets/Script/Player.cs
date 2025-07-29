using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;

    public float speed = 5f;
    public bool isDead = false;
    public float jumpForce = 5f;
    public bool isJumping = false;
    
    
    void Start()
    {
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

    }

    public void FixedUpdate()
    {
      Vector2 velocity = rb.velocity;
      velocity.x = speed;
        if (isJumping)
        {
            velocity.y += jumpForce;
            isJumping = false;
        }
        rb.velocity = velocity;

        float angle =Mathf.Clamp((rb.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
