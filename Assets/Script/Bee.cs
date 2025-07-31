using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;
    float RandomFall = 0f;
    bool isFall = false;
    bool isJump = false;
    public float fallForce = -4f;
    public float JumpForce = 4f;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        RandomFall = Random.Range(1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= RandomFall)
        {
            isFall = true;
                   
            time = 0f;

            return;
        }
       

            Vector2 velocity = rb.velocity;

        if (isFall == true)
        {
            velocity.y += fallForce;
            isFall = false;
        }
      
        rb.velocity = velocity;
    }
}
