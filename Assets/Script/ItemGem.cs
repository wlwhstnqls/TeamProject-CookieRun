using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGem : MonoBehaviour
{
    public float minHeight = 0f;       // �ּ� y ��ġ
    public float maxHeight = 2f;       // �ִ� y ��ġ
    public float distance = 2f;        // ���� ������Ʈ���� �󸶳� ��������

    public Sprite[] gemSprites;       // 0 = Yellow, 1 = Red �߰��ϸ� 2 = Green �̷���..
    private SpriteRenderer sr;

    public int gemScore;  // ���� ���� (1��, 5��)

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        float randomHeight = Random.Range(minHeight, maxHeight);
        Vector3 newPosition = new Vector3(lastPosition.x + distance, randomHeight, 0f);
        transform.position = newPosition;

        // ���� Ȯ�� ����: 0~9 �� 0~8 = Yellow(90%), 9 = Red(10%) �׸� �� �� �߰��� �����ϱ� max���ø���..(��ä��)
        int rand = Random.Range(0, 10);
        if (rand == 9 && gemSprites.Length > 1)
        {
            sr.sprite = gemSprites[1];  // ���� (10%)
            gemScore = 5;
        }
        else
        {
            sr.sprite = gemSprites[0];  // ���ο� (90%)
            gemScore = 1;
        }

        gameObject.SetActive(true); // ��Ȱ��ȭ �� �ʿ�
        return newPosition;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false); // ��Ȱ��ȭ �� BgLooper ��� ���ġ ����
            GameManager.Instance?.AddScore(gemScore);
        }
    }
}
