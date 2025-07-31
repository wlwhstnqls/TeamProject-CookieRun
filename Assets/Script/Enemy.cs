using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float minHeight = -0.3f;    // ��ֹ��� ��ġ�� �ּ� ���� (�ٴ� ����)
    public float maxHeight = 4f;       // ��ֹ��� �������� ��ġ�� �ִ� ����
    public float widthPadding = 3f;    // ��ֹ� ���� (x�� �Ÿ�)

    private float minWidthPadding = 3f;
    private float maxWidthPadding = 5f;

    //public Sprite[] enemySprites;   // ��ֹ� ��������Ʈ ���� �����
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

            // �±׿� ���� y ��ġ �ٸ��� ����
            //if (CompareTag("SkyEnemy"))
            //{
            //    randomY = Random.Range(1.5f, maxHeight);  // �ϴ� ���� ���� ����
            //}
            //else if (CompareTag("GroundEnemy"))
            //{
            //    randomY = -0.55f;                  // ���� ���� y=0.3 ���� �׶��� ������ ���ϰ� 0.3f
            //}

            Vector3 newPosition = new Vector3(lastPosition.x + randomXOffset, randomY, 0);
            transform.position = newPosition;

            // ��������Ʈ ���� ���� (���û���)
            //if (enemySprites != null && enemySprites.Length > 0 && sr != null)
            //{
            //    sr.sprite = enemySprites[Random.Range(0, enemySprites.Length)];
            //}

            return newPosition;
        }
    }
}
