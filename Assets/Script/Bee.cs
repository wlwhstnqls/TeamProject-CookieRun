using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;
    float RandomFall = 0f;
    public float minHeight = -0.3f;    // ��ֹ��� ��ġ�� �ּ� ���� (�ٴ� ����)
    public float maxHeight = 4f;       // ��ֹ��� �������� ��ġ�� �ִ� ����
    public float widthPadding = 3f;    // ��ֹ� ���� (x�� �Ÿ�)

    private float minWidthPadding = 3f;
    private float maxWidthPadding = 5f;

    public Sprite[] enemySprites;   // ��ֹ� ��������Ʈ ���� �����
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

            // �±׿� ���� y ��ġ �ٸ��� ����
            if (CompareTag("SkyEnemy"))
            {
                randomY = Random.Range(1.5f, maxHeight);  // �ϴ� ���� ���� ����
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
