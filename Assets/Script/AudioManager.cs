using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;

    public AudioClip[] audioClip; // 0: ����, 1: 2������, 2: ��, 3: ��Ÿ
    public AudioClip bgmClip; // ������� ��Ƴ��°�, �����߰��ҰŸ� [] �߰��ϸ�˴ϴ�.

    private AudioSource sfxSource; //ȿ����
    private AudioSource bgmSource; //�����

    public static AudioManager Instance => audioManager;

    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;

            // ����� �ҽ� �ʱ�ȭ
            sfxSource = gameObject.AddComponent<AudioSource>();
            bgmSource = gameObject.AddComponent<AudioSource>();

            // BGM ����
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.volume = 0.5f;

            // ���� ���� �� �ڵ� ���
            if (!bgmSource.isPlaying)
                bgmSource.Play();
        }
        else
        {
            Destroy(gameObject); // �ν��Ͻ� �ߺ� ����
        }
    }

    // ���� ���
    public void JumpSound(int idx)
    {
        sfxSource.PlayOneShot(audioClip[idx]);
    }

    public void PlayGemSound()
    {
        sfxSource.PlayOneShot(audioClip[2]);
    }

    public void PlayStarSound()
    {
        sfxSource.PlayOneShot(audioClip[3]);
    }

    // BGM ����
    public void PlayBGM() 
    {
        if (!bgmSource.isPlaying)
            bgmSource.Play();
    }

    public void StopBGM() //
    {
        if (bgmSource.isPlaying)
            bgmSource.Stop();
    }

    // ���� ���� (UI���� ����, �����̵� �������)
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
