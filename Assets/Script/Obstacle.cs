using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minHeight = 0f;       // 장애물이 배치될 최소 높이 (바닥 기준)
    public float maxHeight = 2f;       // 장애물이 랜덤으로 배치될 최대 높이
    public float widthPadding = 4f;    // 장애물 간격 (x축 거리)

    public Sprite[] obstacleSprites;   // 장애물 스프라이트 랜덤 적용용
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        // 높이를 랜덤으로 설정 (지형 변화를 주기 위함)
        float randomHeight = Random.Range(minHeight, maxHeight);

        // 장애물 새 위치
        Vector3 newPosition = lastPosition + new Vector3(widthPadding, randomHeight, 0);

        // 장애물 위치 적용
        transform.position = newPosition;

        // 랜덤 스프라이트 적용 (선택 사항)
        if (obstacleSprites != null && obstacleSprites.Length > 0 && sr != null)
        {
            sr.sprite = obstacleSprites[Random.Range(0, obstacleSprites.Length)];
        }

        return newPosition;
    }
}
