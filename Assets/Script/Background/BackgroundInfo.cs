using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInfo : MonoBehaviour
{
    public BackgroundType type;

    [Header("색 설정")]
    public Color skyColor;     // 카메라 backgroundColor에 쓸 하늘색
    public Color fadeDayColor; // Sprite 밝은색
    public Color fadeNightColor; // Sprite 어두운색
}


//메인카메라와 점프했을때 하늘색이 같으면 어색하니 다르게 하고싶은데..