using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour

{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI achievementListText;

    // Start is called before the first frame update
    void Start()
    {
        int LoadedScore = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = LoadedScore.ToString();

        ShowAchievements();

        // 업적 불러오기
        void ShowAchievements()
        {
            List<string> achievements = Achievement.Instance.GetAchievementsThisGame();

            if (achievements.Count == 0)
            {
                achievementListText.text = "획득한 업적이 없습니다.";
            }
            else
            {
                achievementListText.text = string.Join("\n", achievements);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
