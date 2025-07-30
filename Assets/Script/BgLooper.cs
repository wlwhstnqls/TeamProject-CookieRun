using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 16;
    public int obstacleCount = 0;
    public int numGroundCount = 16;
    public Vector3 obstacleLastPosition = Vector3.zero; //마지막 장애물이 위치한 곳의 좌표를 저장

    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();  // 씬에 있는 모든 Obstacle(장애물) 객체를 찾아 배열에 저장
        obstacleCount = obstacles.Length;
        //obstacleLastPosition = obstacles[0].transform.position;

        if (obstacleCount > 0)
        {
            obstacleLastPosition = obstacles[0].transform.position;

            for (int i = 0; i < obstacleCount; i++)
            {
                obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, i);
            }
        }
        else
        {
            Debug.Log("장애물이 없습니다..."); // 장애물이없으면 Null값에러떠서 실행안됨!(게임멈춤현상)
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround") || (collision.CompareTag("Ground")))   // 충돌한 객체가 "BackGround" 또는 "Ground" 태그를 가지고 있다면
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x; // 충돌한 오브젝트의 가로 길이(BoxCollider2D 기준)를 구함
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        
         
        Obstacle obstacle = collision.GetComponent<Obstacle>(); // 만약 충돌한 객체가 장애물(Obstacle)이라면
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount); // 해당 장애물을 새로운 위치로 이동
        }
    }
}