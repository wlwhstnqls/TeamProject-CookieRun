using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundFader : MonoBehaviour
{
    private SpriteRenderer[] backgroundRenderers;  // 배경에 붙은 여러 스프라이트를 담을 배열

    public Color dayColor = Color.white; //원래색상
    public Color nightColor = new Color(0.2f, 0.2f, 0.2f); // 회색으로 어두워진 느낌줌

    // 카메라 배경색용 색상 (r46 g204 b112 기준)
    public Color cameraDayColor = new Color(46f / 255f, 204f / 255f, 112f / 255f);
    public Color cameraNightColor = new Color(0.05f, 0.2f, 0.1f); // 어두운 녹색 톤

    // 각 맵별로 페이드 진행 정도를 따로 관리
    private float[] fadeProgresses;
    private bool[] isFadingOut; // true면 어두워지는 중, false면 밝아지는 중

    private float cameraFadeProgress = 1f; // 배경 스프라이트 각각의 페이드 진행 정도 저장 (0~1)
    private bool cameraFadingOut = true;  // 각 스프라이트가 어두워지는 중인지 밝아지는 중인지 상태 저장 (true면 어두워지는 중)

    private Camera mainCam;

    void Start()
    {
        backgroundRenderers = GetComponentsInChildren<SpriteRenderer>(); //자식의 SpriteRenderer를 전부가져옵니다.
        fadeProgresses = new float[backgroundRenderers.Length]; // fader값을 저장할 배열생성
        isFadingOut = new bool[backgroundRenderers.Length];

        //처음에는 모두 완전히 밝은 상태(1f)로 초기화
        for (int i = 0; i < fadeProgresses.Length; i++)
            fadeProgresses[i] = 1f;

        mainCam = Camera.main;
        if (mainCam != null)
            mainCam.backgroundColor = cameraDayColor; // 초기 카메라 배경색 설정
    }

    void Update()
    {
        for (int i = 0; i < backgroundRenderers.Length; i++)
        {
            if (isFadingOut[i])
            {
                fadeProgresses[i] -= Time.deltaTime * 0.01f; // 어두워지기
                fadeProgresses[i] = Mathf.Clamp01(fadeProgresses[i]); // 밝기의 max 1로 설정

                //Debug.Log($"[{i}] Fade Progress 내려감 (어두워짐): {fadeProgresses[i]:F3}, nightColor: {nightColor}");

                if (fadeProgresses[i] <= 0f)
                {
                    fadeProgresses[i] = 0f;
                    isFadingOut[i] = false; // 밝아지기로 전환
                }
            }
            else
            {
                fadeProgresses[i] += Time.deltaTime * 0.01f; // 밝아지기
                fadeProgresses[i] = Mathf.Clamp01(fadeProgresses[i]);

                //Debug.Log($"[{i}] Fade Progress 올라감 (밝아짐): {fadeProgresses[i]:F3}, nightColor: {nightColor}");

                if (fadeProgresses[i] >= 1f)
                {
                    fadeProgresses[i] = 1f;
                    isFadingOut[i] = true; // 어두워지기로 전환
                }
            }

            Color currentColor = Color.Lerp(nightColor, dayColor, fadeProgresses[i]);
            backgroundRenderers[i].color = currentColor;
        }

        if (mainCam != null)
        {
            if (cameraFadingOut)
            {
                cameraFadeProgress -= Time.deltaTime * 0.01f;
                cameraFadeProgress = Mathf.Clamp01(cameraFadeProgress);

                if (cameraFadeProgress <= 0f)
                    cameraFadingOut = false;
            }
            else
            {
                cameraFadeProgress += Time.deltaTime * 0.01f;
                cameraFadeProgress = Mathf.Clamp01(cameraFadeProgress);

                if (cameraFadeProgress >= 1f)
                    cameraFadingOut = true;
            }
            mainCam.backgroundColor = Color.Lerp(cameraNightColor, cameraDayColor, cameraFadeProgress);
        }
    }


    // 외부에서 맵 페이트값을 바꿀때 쓰시면됩니다.
    public void SetFadeProgress(int index, float progress)
    {
        if (index >= 0 && index < fadeProgresses.Length)
            fadeProgresses[index] = Mathf.Clamp01(progress);
    }
}
