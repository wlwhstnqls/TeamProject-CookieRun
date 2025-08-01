using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour

{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        int LoadedScore = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = LoadedScore.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
