using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 16;
    public int enemyCount = 0;
    public int numGroundCount = 16;
    public Vector3 enemyLastPosition = Vector3.zero;

    public static BgLooper Instance;
    public Vector3 gemLastPosition = Vector3.zero;
    public float gemDistance = 0.02f;

    public enemy enemyPrefab;
    private List<enemy> activeenemys = new List<enemy>();

    private float difficultyTimer = 0f;
    public float spawnInterval = 5f;
    public float minSpawnInterval = 2f;
    public float intervalDecreaseRate = 0.05f;

    public Transform player;

    private void Awake()
    {
        Instance = this; //자기자신인스턴스화
    }


    void Start()
    {
        enemy[] enemys = GameObject.FindObjectsOfType<enemy>();
        enemyCount = enemys.Length;

        if (enemyCount > 0)
        {
            enemyLastPosition = enemys[0].transform.position;

            for (int i = 0; i < enemyCount; i++)
            {
                enemyLastPosition = enemys[i].SetRandomPlace(enemyLastPosition, i);
                activeenemys.Add(enemys[i]);
            }
        }
        else
        {
            Debug.Log("장애물이 없습니다...");
        }
        if (player != null)
            gemLastPosition = player.position + new Vector3(0.01f, 0f, 0f);

        // 씬에 있는 보석 모두 처음 재배치
        ItemGem[] gems = GameObject.FindObjectsOfType<ItemGem>();
        foreach (var gem in gems)
        {
            gemLastPosition = RepositionGem(gem);
        }
    }

    void Update()
    {
        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= spawnInterval)
        {
            difficultyTimer = 0f;
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("충돌 감지: " + collision.name);
        if (collision.CompareTag("BackGround") || collision.CompareTag("Ground"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;
            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        enemy enemy = collision.GetComponentInParent<enemy>();
        if (enemy) 
        {
            //Debug.Log("장애물 충돌 감지: " + enemy.name);
            enemyLastPosition = enemy.SetRandomPlace(enemyLastPosition, enemyCount);
        }

        if (collision.CompareTag("Gem"))
        {
            ItemGem gem = collision.GetComponent<ItemGem>();
            if (gem != null)
            {
                // 보석을 마지막 위치에서 일정 거리 앞으로 이동
                Vector3 newPos = new Vector3(gemLastPosition.x + gemDistance, gem.transform.position.y, gem.transform.position.z);
                gem.transform.position = newPos;

                // 새 위치를 마지막 위치로 업데이트
                gemLastPosition = newPos;
            }
        }
    }

    public Vector3 RepositionGem(ItemGem gem)
    {
        Vector3 newPos = new Vector3(gemLastPosition.x + gemDistance, Random.Range(gem.minHeight, gem.maxHeight), 0f);
        Vector3 updatedPos = gem.SetRandomPlace(newPos);
        return updatedPos;
    }
    public void HandleGemRespawn(ItemGem gem) //아이템잼의 먹음효과를 대신처리해주기
    {
        gemLastPosition = gem.SetRandomPlace(gemLastPosition);
    }
}
