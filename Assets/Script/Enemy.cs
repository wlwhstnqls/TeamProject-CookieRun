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
