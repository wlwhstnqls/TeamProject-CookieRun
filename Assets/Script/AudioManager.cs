using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;
    public AudioClip[] audioClip;
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
}
