using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggerd: " + collision.name);

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
