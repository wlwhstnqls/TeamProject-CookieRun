using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    public static Achievement Instance;

    private bool unlocked100 = false;
    private bool unlocked500 = false;
    private bool unlocked1000 = false;

    private List<string> unlockedAchievementsThisGame = new List<string>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CheckScoreAchievements(int score)
    {
        if (score >= 100 && !unlocked100)
        {
            unlocked100 = true;
            Unlock("100점 돌파!");
        }

        if (score >= 500 && !unlocked500)
        {
            unlocked500 = true;
            Unlock("500점 돌파!");
        }

        if (score >= 1000 && !unlocked1000)
        {
            unlocked1000 = true;
            Unlock("1000점 돌파!");
        }
    }

    private void Unlock(string achievementName)
    {
        Debug.Log("업적 달성: " + achievementName);
        UIManager.Instance?.ShowAchievement(achievementName);

        // 이번 게임 업적 목록에 추가
        unlockedAchievementsThisGame.Add(achievementName);
    }

    // 엔드씬에서 접근용
    public List<string> GetUnlockedAchievementsThisGame()
    {
        return unlockedAchievementsThisGame;
    }

    public void ResetAchievements()
    {
        unlocked100 = false;
        unlocked500 = false;
        unlocked1000 = false;
        unlockedAchievementsThisGame.Clear();
    }
}
