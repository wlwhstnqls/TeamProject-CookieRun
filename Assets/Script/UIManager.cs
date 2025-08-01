using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // ���ڷ� ���� ǥ��
        }
        else
        {
            Debug.LogWarning("ScoreText�� UIManager�� ������� �ʾҽ��ϴ�.");
        }
    }
}
