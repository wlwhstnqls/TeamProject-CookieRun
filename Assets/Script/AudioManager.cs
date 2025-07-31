using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;
    public AudioClip[] audioClip; // 0: ¡°«¡, 1: 2¥‹¡°«¡, 2: ¿Î»πµÊ , 3: Ω∫≈∏, «œ∆Æ»πµÊ
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
<<<<<<< HEAD

    }

    public void PlayGemSound()
    {
        audioSource.PlayOneShot(audioClip[2]); 
    }
    public void PlayStarSound()
    {
        audioSource.PlayOneShot(audioClip[3]);
=======
>>>>>>> jihan
    }
}
