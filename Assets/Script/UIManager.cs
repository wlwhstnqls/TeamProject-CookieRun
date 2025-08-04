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
    //void Update()
    //{
    //    // 클릭하면 언제든 게임 재시작 가능
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //        //Debug.Log("마우스 클릭 감지되면 씬 리로드");
    //    }

    //}
    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // 숫자로 점수 표시
        }
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        //Debug.Log("점수저장중");
        //else
        //{
        //    Debug.LogWarning("ScoreText가 UIManager에 연결되지 않았습니다.");
        //}
    }

    
}
