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
    public Vector3 SetRandomPlace(Vector3 lastPosition, int enemyCount)
    {
        {
            float randomXOffset = Random.Range(minWidthPadding, maxWidthPadding);
            float randomY = Random.Range(minHeight, maxHeight); 
            Vector3 newPosition = new Vector3(lastPosition.x + randomXOffset, randomY, 0);
            transform.position = newPosition;
            return newPosition;
        }
    }   
}
