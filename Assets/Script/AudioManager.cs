using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;
    
    public static AudioManager Instance
    {
        get { return audioManager; }
    }

    private void Awake()
    {
        audioManager = this;
    }
    void Start()
    {
        GetComponent<AudioSource>().mute = true;
        GetComponents<AudioSource>()[1].mute = true; 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void JumpSound(int idx)
    {
        
        if (idx == 0)
        {
            GetComponent<AudioSource>().mute = false;
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip); // 첫번째 점프 사운드 재생
        }
        else if (idx == 1)
        {
            GetComponents<AudioSource>()[1].mute = false;
            AudioSource audioSource = GetComponents<AudioSource>()[1];
            audioSource.PlayOneShot(audioSource.clip); // 두번째 점프 사운드 재생
        }
    }
}
