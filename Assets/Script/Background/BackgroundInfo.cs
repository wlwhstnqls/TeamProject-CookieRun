using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInfo : MonoBehaviour
{
    public BackgroundType type;

    [Header("�� ����")]
    public Color skyColor;     // ī�޶� backgroundColor�� �� �ϴû�
    public Color fadeDayColor; // Sprite ������
    public Color fadeNightColor; // Sprite ��ο��
}


//����ī�޶�� ���������� �ϴû��� ������ ����ϴ� �ٸ��� �ϰ������..