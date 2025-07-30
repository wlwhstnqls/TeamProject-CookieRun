using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0;
    public int numGroundCount = 5;
    public Vector3 obstacleLastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
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
            Debug.Log("장애물이 없습니다...");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x * collision.transform.localScale.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        if (collision.CompareTag("Ground"))
        {
            float widthOfGround = ((BoxCollider2D)collision).size.x * collision.transform.localScale.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfGround * numGroundCount; // 반복 횟수만큼 x축 이동
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}