using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGem : MonoBehaviour
{
    public float minHeight = 0f;       // 최소 y 위치
    public float maxHeight = 2f;       // 최대 y 위치
    public float distance = 0.1f;        // 이전 오브젝트보다 얼마나 떨어질지

    public Sprite[] gemSprites;       // 0=Yellow, 1=Red, 2=Green, 3=Blue, 4=Star, 5=Heart 등 더추가할게있는지?
    private SpriteRenderer sr;

    public int gemScore;  // 보석 점수 (1점, 5점, 100, 500, 무적, 목숨추가)
    public enum GemType { Yellow, Red, Green, Blue, Star, Heart } //배열용 이넘
    public GemType gemType;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        float randomHeight = Random.Range(minHeight, maxHeight);
        Vector3 newPosition = new Vector3(lastPosition.x + distance, randomHeight, 0f);
        transform.position = newPosition;

        float rand = Random.Range(0f, 100f);

        if (rand < 5f)
        {
            SetGem(GemType.Heart, 5); //test를 위해 Heart->Yellow로 바꿔둔상태 테스트끝나면 확률 및 원복
        }
        else if (rand < 10f)
        {
            SetGem(GemType.Star, 0);
        }
        else if (rand < 5f)
        {
            SetGem(GemType.Blue, 500);
        }
        else if (rand < 10f)
        {
            SetGem(GemType.Green, 100);
        }
        else if (rand < 25.0f)
        {
            SetGem(GemType.Red, 5);
        }
        else
        {
            SetGem(GemType.Yellow, 1);
        }

        return newPosition;
    }

    private void SetGem(GemType type, int score) //잼의 타입 그리고 점수
    {
        gemType = type;
        gemScore = score;
        sr.sprite = gemSprites[(int)type];
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        switch (gemType)
        {
            case GemType.Yellow:
            case GemType.Red:
            case GemType.Green:
            case GemType.Blue:
                ScoreManager.Instance?.AddScore(gemScore);
                AudioManager.Instance?.PlayGemSound();
                break;

            case GemType.Star:
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    Debug.Log("무적 스타 획득!");
                    player.StartInvincible();
                    AudioManager.Instance?.PlayStarSound();
                }
                break;

            case GemType.Heart:
                // 목숨 추가 처리 예정
                Debug.Log("하트 획득! (생명 +1)");
                Player p = other.GetComponent<Player>();
                if (p != null)
                {
                    p.GainLife(); // 생명 증가 처리
                }
                AudioManager.Instance?.PlayStarSound();
                break;
        }

        // BgLooper가 재배치 하도록 요청
        BgLooper.Instance?.HandleGemRespawn(this);
        }
    }

