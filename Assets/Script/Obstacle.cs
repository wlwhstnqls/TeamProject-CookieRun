using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minHeight = 0f;       // ��ֹ��� ��ġ�� �ּ� ���� (�ٴ� ����)
    public float maxHeight = 2f;       // ��ֹ��� �������� ��ġ�� �ִ� ����
    public float widthPadding = 4f;    // ��ֹ� ���� (x�� �Ÿ�)

    public Sprite[] obstacleSprites;   // ��ֹ� ��������Ʈ ���� �����
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        // ���̸� �������� ���� (���� ��ȭ�� �ֱ� ����)
        float randomHeight = Random.Range(minHeight, maxHeight);

        // ��ֹ� �� ��ġ
        Vector3 newPosition = lastPosition + new Vector3(widthPadding, randomHeight, 0);

        // ��ֹ� ��ġ ����
        transform.position = newPosition;

        // ���� ��������Ʈ ���� (���� ����)
        if (obstacleSprites != null && obstacleSprites.Length > 0 && sr != null)
        {
            sr.sprite = obstacleSprites[Random.Range(0, obstacleSprites.Length)];
        }

        return newPosition;
    }
}
