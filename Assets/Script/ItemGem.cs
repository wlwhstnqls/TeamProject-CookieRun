using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGem : MonoBehaviour
{
    public float minHeight = 0f;       // 최소 y 위치
    public float maxHeight = 2f;       // 최대 y 위치
    public float distance = 10f;        // 이전 오브젝트보다 얼마나 떨어질지

    public Sprite[] gemSprites;       // 0 = Yellow, 1 = Red 등
    private SpriteRenderer sr;

    public int gemScore;  // 보석 점수 (1점, 5점)

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        float randomHeight = Random.Range(minHeight, maxHeight);
        Vector3 newPosition = new Vector3(lastPosition.x + distance, randomHeight, 0f);
        transform.position = newPosition;

        int rand = Random.Range(0, 10);
        if (rand == 9 && gemSprites.Length > 1)
        {
            sr.sprite = gemSprites[1];  // 레드 (10%)
            gemScore = 5;
        }
        else
        {
            sr.sprite = gemSprites[0];  // 옐로우 (90%)
            gemScore = 1;
        }

        return newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance?.AddScore(gemScore);
            // 즉시 재배치 (현재 위치 기준)
            SetRandomPlace(transform.position);
        }
    }
}
