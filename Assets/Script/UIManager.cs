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
        // ����� �ؽ�Ʈ�� �׻� ���̵��� ���� ���ӿ��� ���� �����Ǹ� �׶� ����
        if (restartText != null)
            restartText.gameObject.SetActive(true);
    }
    //void Update()
    //{
    //    // Ŭ���ϸ� ������ ���� ����� ����
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //        //Debug.Log("���콺 Ŭ�� �����Ǹ� �� ���ε�");
    //    }

    //}
    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // ���ڷ� ���� ǥ��
        }
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        //Debug.Log("����������");
        //else
        //{
        //    Debug.LogWarning("ScoreText�� UIManager�� ������� �ʾҽ��ϴ�.");
        //}
    }

    
}
