using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;
    public AudioClip[] audioClip; // 0: ����, 1: 2������, 2: ��ȹ�� , 3: ��Ÿ, ��Ʈȹ��
    private AudioSource audioSource;

    public static AudioManager Instance
    {
        get { return audioManager; }
    }
   

    private void Awake()
    {
        audioManager = this;
        audioSource = GetComponent<AudioSource>();
    }
          
   
    public void JumpSound(int idx)
    {
        audioSource.PlayOneShot(audioClip[idx]);


    }

    public void PlayGemSound()
    {
        audioSource.PlayOneShot(audioClip[2]); 
    }
    public void PlayStarSound()
    {
        audioSource.PlayOneShot(audioClip[3]);


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
