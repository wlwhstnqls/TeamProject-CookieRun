using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;

    public AudioClip[] audioClip; // 0: 점프, 1: 2단점프, 2: 잼, 3: 스타
    public AudioClip bgmClip; // 배경음악 담아놓는곳, 음악추가할거면 [] 추가하면됩니다.

    private AudioSource sfxSource; //효과음
    private AudioSource bgmSource; //배경음

    public static AudioManager Instance => audioManager;

    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;

            // 오디오 소스 초기화
            sfxSource = gameObject.AddComponent<AudioSource>();
            bgmSource = gameObject.AddComponent<AudioSource>();

            // BGM 세팅
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.volume = 0.5f;

            // 게임 시작 시 자동 재생
            if (!bgmSource.isPlaying)
                bgmSource.Play();
        }
        else
        {
            Destroy(gameObject); // 인스턴스 중복 방지
        }
    }

    // 사운드 재생
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

    // BGM 제어
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

    // 볼륨 조절 (UI에서 연결, 슬라이드 조절기능)
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
