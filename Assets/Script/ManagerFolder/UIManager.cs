using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        // 재시작 텍스트가 항상 보이도록 설정 게임오버 로직 구현되면 그때 수정
        if (restartText != null)
            restartText.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // 숫자로 점수 표시
        }
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
