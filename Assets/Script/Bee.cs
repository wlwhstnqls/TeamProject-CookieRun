using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;
    float RandomFall = 0f;
    public float minHeight = -0.3f;    // 장애물이 배치될 최소 높이 (바닥 기준)
    public float maxHeight = 4f;       // 장애물이 랜덤으로 배치될 최대 높이
    public float widthPadding = 3f;    // 장애물 간격 (x축 거리)

    private float minWidthPadding = 3f;
    private float maxWidthPadding = 5f;

    public Sprite[] enemySprites;   // 장애물 스프라이트 랜덤 적용용
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }



    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int enemyCount)
    {
        {
            float randomXOffset = Random.Range(minWidthPadding, maxWidthPadding);
            float randomY = minHeight;

            // 태그에 따라 y 위치 다르게 설정
            if (CompareTag("SkyEnemy"))
            {
                randomY = Random.Range(1.5f, maxHeight);  // 하늘 적은 높이 랜덤
            }
           

            Vector3 newPosition = new Vector3(lastPosition.x + randomXOffset, randomY, 0);
            transform.position = newPosition;

            return newPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {

     

    }

   
}
