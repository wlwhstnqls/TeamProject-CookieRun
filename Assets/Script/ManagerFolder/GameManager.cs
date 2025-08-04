using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject EndPopUp;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        Invoke("TimeStop", 1.5f);
    }

    void TimeStop()
    {
        EndPopUp.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GotoEndScene()
    {
        SceneManager.LoadScene("RealEndScene");
    }
   
}
