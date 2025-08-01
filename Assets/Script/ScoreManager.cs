using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0; 

    static ScoreManager scoreManager;

    public static ScoreManager Instance { get { return scoreManager; } }
    // Start is called before the first frame update
    public void Awake()
    {
        scoreManager = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"[획득] +{score}점 | 현재 점수: {currentScore}");
        UIManager.Instance.UpdateScore(currentScore); // 점수 UI 업데이트 호출
    }
    public int GetScore()
    {
        return currentScore;
    }
    public void ResetScore()
    {
        currentScore = 0;
    }
}
