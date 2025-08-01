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
    

    public void AddScore(int score)
    {
        currentScore += score;
        //Debug.Log($"[획득] +{score}점 | 현재 점수: {currentScore}");
      
        if (UIManager.Instance != null)  // UI 점수 호출
            UIManager.Instance.UpdateScore(currentScore);
    }
    public int GetScore()
    {
        return currentScore;
    }
    public void ResetScore()
    {
        currentScore = 0;
        if (UIManager.Instance != null)
            UIManager.Instance.UpdateScore(currentScore);
    }
   
}
