using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;

    public Animator[] heartAnimators; // Inspector에 3개 넣기

    void Start()
    {
        Camera.main.GetComponent<FollowCamera>().player = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
    }

    public void LoseHeart(int currentLife)
    {
        int lostIndex = heartAnimators.Length - 1 - currentLife;
        if (lostIndex >= 0 && lostIndex < heartAnimators.Length)
        {
            heartAnimators[lostIndex].SetTrigger("LostHeart");
        }
    }
    public void RecoverHeart(int currentLife)
    {
        int recoverIndex = heartAnimators.Length - currentLife;
        if (recoverIndex >= 0 && recoverIndex < heartAnimators.Length)
        {
            heartAnimators[recoverIndex].ResetTrigger("LostHeart"); // 트리거 초기화
            heartAnimators[recoverIndex].SetTrigger("Heart"); // 복구 트리거
        }
    }

}
