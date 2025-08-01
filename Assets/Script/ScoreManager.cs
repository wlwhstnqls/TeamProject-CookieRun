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
        //Debug.Log($"[ȹ��] +{score}�� | ���� ����: {currentScore}");
      
        if (UIManager.Instance != null)  // UI ���� ȣ��
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
