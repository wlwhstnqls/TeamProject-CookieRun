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
    SpriteRenderer spriteRenderer = null;

    public float speed = 5f;
    public bool isDead = false;
    public float jumpForce = 8f;
    public bool isJumping = false;
    float time = 0f;

    public int life = 3; //해당 라이프 3개
    public Hearts heartsUI; //하트 UI 스크립트 연결(생명 수 표시용)

    public bool invincible = false; // 무적 상태 테스트끝나고 private로 바꿔주세요
    private float invincibleDuration = 2.0f; // 무적 지속시간
    private float invincibleTimer = 0f;

   

    public bool GodMode = false; // Inspector 체크박스 on시 영구무적

    int JumpCount = 0;
    int MaxJumpCount = 2;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (GodMode)
        {
            invincible = true;
            return; // 테스트 중에는 아래 로직 무시
        }
        // 무적 타이머
        if (invincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0f)
            {
                invincible = false;
                Debug.Log("무적 해제됨 (invincible = false)");
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);


                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
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
            // 무적 상태면 충돌 무시 
            if (invincible == true)
            {
                
                Debug.Log("무적 활성화 중, 장애물 통과!");
                return; 
            }

            life--; // 목숨 1 감소

            heartsUI?.LoseHeart(life);

            if (life <= 0)
            {
                Die(); //IsDead는  상태확인용, Die는 죽음을 의미합니다.
            }
            else
            {
                StartInvincible(); // 무적 시작
            }
        }
    }
    public void GainLife() // 목숨 회복 함수 (하트 아이템 획득 시 호출)
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
    public void StartInvincible() // 무적 시작 함수
    {
        invincible = true;
        invincibleTimer = invincibleDuration;
        
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.2f);
        
       
        Debug.Log("무적 시작됨 (invincible = true)");
        // 이펙트나 깜빡임 애니메이션 추가해야함 
        // animator.SetBool("IsGodMode", true); 필요시 활성화

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
    }

    private void Die() // 플레이어 사망 처리 함수
    {
        if (isDead) return;  // 이미 사망 처리 됐으면 중복 실행 방지

        isDead = true;
        animator.SetTrigger("IsDead");
        GameManager.Instance.GameOver(); // 게임 매니저에 게임 오버 알림 그래야 고투엔드씬호출됩니다.
    }
}
