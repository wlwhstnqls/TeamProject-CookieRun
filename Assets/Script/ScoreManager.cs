using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{


   
    private int currentScore = 0;
   

    public static ScoreManager scoreManager;

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
        UIManager.Instance.UpdateScore(currentScore); // 점수 UI 업데이트 호출

        if (UIManager.Instance != null)  // UI 갱신
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
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", currentScore);
        PlayerPrefs.Save();
        Debug.Log("점수저장중");
    }

}
