using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    // 다음 맵 불러오면서 camera 색 변경 (페이더(새벽)에서 -> 트리(초원) -> 사막 -> 다시 페이더)
    //void SpawnNextBackground()
    //{
    //    currentIndex++;
    //    GameObject nextBG = Instantiate(backgroundPrefabs[currentIndex % backgroundPrefabs.Length], spawnPosition, Quaternion.identity);

    // 맵 종류에 따라 색상도 지정
    //    if (nextBG.CompareTag("Desert"))
    //    {
    //        StartCoroutine(fader.FadeToColor(desertColor));
    //    }
    //    else if (nextBG.CompareTag("Morning"))
    //    {
    //        StartCoroutine(fader.FadeToColor(MorningColor));
    //    }
    //}

}
