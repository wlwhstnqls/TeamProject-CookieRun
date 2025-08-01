using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int life = 3; //해당 라이프 3개
    public Hearts heartsUI;

    public bool godMode = false; // 테스트 끝나고 꼭 private으로 바꿔주세요!!
    private float godModeDuration = 2.0f;
    private float godModeTimer = 0f;


    int JumpCount = 0;
    int MaxJumpCount = 2;

    void Start()
    {

        Camera.main.GetComponent<FollowCamera>().player = transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
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
            speed += 0.2f;
            time = 0f;
            return;
        }
        // GodMode 타이머
        if (godMode)
        {
            godModeTimer -= Time.deltaTime;
            if (godModeTimer <= 0f)
            {
                godMode = false;
                Debug.Log("GodMode 해제됨");
            }
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
            AudioManager.Instance.JumpSound(JumpCount);
            JumpCount++;
            isJumping = false;
        }
        //Debug.Log("JumpCount: " + JumpCount);
        rb.velocity = velocity;

        float angle = Mathf.Clamp((rb.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 0.64f, LayerMask.GetMask("Ground"));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (godMode)
            {
                Debug.Log("GodMode 활성화 중, 장애물 통과!");
                return; // 충돌 무시
            }

            life--;
            heartsUI?.LoseHeart(life);

            if (life <= 0)
            {
                Die();
            }
            else
            {
                StartGodMode(); // 무적 시작
            }
        }
    }
    public void GainLife()
    {
        if (life < 3)
        {
            life++;
            if (heartsUI != null)
            {
                heartsUI.RecoverHeart(life); // 여기서 RecoverHeart 함수 호출, 내부 트리거는 "Heart"

            }
        }
    }
    public void StartGodMode()
    {
        godMode = true;
        godModeTimer = godModeDuration;

        Debug.Log("GodMode 활성화됨 (무적 상태)");
        // 이펙트나 깜빡임 애니메이션 추가해야함
        // animator.SetBool("IsGodMode", true); 필요시 활성화
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("IsDead");
        GameManager.Instance.GameOver();
    }
}
