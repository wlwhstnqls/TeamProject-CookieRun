using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float minHeight = -0.3f;    // 장애물이 배치될 최소 높이 (바닥 기준)
    public float maxHeight = 4f;       // 장애물이 랜덤으로 배치될 최대 높이
    public float widthPadding = 3f;    // 장애물 간격 (x축 거리)

    private float minWidthPadding = 3f;
    private float maxWidthPadding = 5f;

    //public Sprite[] enemySprites;   // 장애물 스프라이트 랜덤 적용용
    //private SpriteRenderer sr;

    //void Awake()
    //{
    //    sr = GetComponent<SpriteRenderer>();
    //}

    public Vector3 SetRandomPlace(Vector3 lastPosition, int enemyCount)
    {
        {
            float randomXOffset = Random.Range(minWidthPadding, maxWidthPadding);
            float randomY = Random.Range(minHeight, maxHeight); 

            // 태그에 따라 y 위치 다르게 설정
            //if (CompareTag("SkyEnemy"))
            //{
            //    randomY = Random.Range(1.5f, maxHeight);  // 하늘 적은 높이 랜덤
            //}
            //else if (CompareTag("GroundEnemy"))
            //{
            //    randomY = -0.55f;                  // 지상 적은 y=0.3 고정 그라운드 레벨과 동일값 0.3f
            //}

            Vector3 newPosition = new Vector3(lastPosition.x + randomXOffset, randomY, 0);
            transform.position = newPosition;

            // 스프라이트 랜덤 적용 (선택사항)
            //if (enemySprites != null && enemySprites.Length > 0 && sr != null)
            //{
            //    sr.sprite = enemySprites[Random.Range(0, enemySprites.Length)];
            //}

            return newPosition;
        }
    }
}
