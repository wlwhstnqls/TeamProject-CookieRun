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
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void JumpSound(int idx)
    {
        if (idx == 1)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip); // 첫번째 점프 사운드 재생
        }
        //else if (idx == 1)
        //{
           // AudioSource audioSource = GetComponents<AudioSource>()[1];
           // audioSource.PlayOneShot(audioSource.clip); // 두번째 점프 사운드 재생
        //}
    }
}
