using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 16;
    public int enemyCount = 0;
    public int numGroundCount = 16;
    public Vector3 enemyLastPosition = Vector3.zero; //마지막 장애물이 위치한 곳의 좌표를 저장

    public enemy enemyPrefab; // 새 장애물 생성용 프리팹
    private List<enemy> activeenemys = new List<enemy>();

    // 난이도(장애물 개수 증가 관련)
    private float difficultyTimer = 0f;
    public float spawnInterval = 5f; // 몇 초마다 새로운 장애물 추가
    public float minSpawnInterval = 2f;        // 최소 간격
    public float intervalDecreaseRate = 0.05f; // 시간이 지날수록 간격 감소

    // Start is called before the first frame update
    void Start()
    {
        enemy[] enemys = GameObject.FindObjectsOfType<enemy>();  // 씬에 있는 모든 enemy(장애물) 객체를 찾아 배열에 저장
        enemyCount = enemys.Length;
        //enemyLastPosition = enemys[0].transform.position;

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
            Debug.Log("장애물이 없습니다..."); // 장애물이없으면 Null값에러떠서 실행안됨!(게임멈춤현상)
        }
    }

    void Update()
    {
        // 난이도 시간 누적
        difficultyTimer += Time.deltaTime;

        // 일정 시간마다 새로운 장애물 생성
        if (difficultyTimer >= spawnInterval)
        {
            difficultyTimer = 0f;
            SpawnNewenemy();

            // 난이도 상승 → 스폰 간격 조금씩 감소
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("BackGround") || (collision.CompareTag("Ground")))   // 충돌한 객체가 "BackGround" 또는 "Ground" 태그를 가지고 있다면
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x; // 충돌한 오브젝트의 가로 길이(BoxCollider2D 기준)를 구함
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }



        enemy enemy = collision.GetComponent<enemy>(); // 만약 충돌한 객체가 장애물(enemy)이라면
        if (enemy)
        {
            enemyLastPosition = enemy.SetRandomPlace(enemyLastPosition, enemyCount); // 해당 장애물을 새로운 위치로 이동
        }
    }
    private void SpawnNewenemy()
    {
        // 새로운 장애물 생성 및 배치
        enemy newenemy = Instantiate(enemyPrefab);
        enemyLastPosition = newenemy.SetRandomPlace(enemyLastPosition, enemyCount);
        activeenemys.Add(newenemy);
        enemyCount++;
        Debug.Log("새 장애물 생성됨! 현재 장애물 수: " + enemyCount);
    }

}