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

    public void LoseHeart(int currentLife) //하트가 줄어들때 호출되는 함수(에너미와 충돌시 호출함) currentLife : 현재 플레이어 생명 수 (0부터 최대 3까지 등)
    {
        //최대 하트가 3개일 때 currentLife가 2면, 잃는 하트는 heartAnimators[0] (마지막에서 1번째) 쉽게말해 왼쪽부터 없어짐
        int lostIndex = heartAnimators.Length - 1 - currentLife;
        // 인덱스가 유효한 범위일 때만 애니메이터 트리거 실행
        if (lostIndex >= 0 && lostIndex < heartAnimators.Length)
        {
            // 하트가 사라지는 애니메이션 실행
            heartAnimators[lostIndex].SetTrigger("LostHeart");
        }
    }
    public void RecoverHeart(int currentLife) // ItemGem에서 하트를 먹었을때 호출되는 함수
    {
        // 회복할 하트 애니메이터 인덱스 계산
        int recoverIndex = heartAnimators.Length - currentLife;
        // 인덱스가 유효하면, 이전에 LostHeart 트리거를 초기화 (트리거는 한 번만 동작하므로 초기화 필요) 반복해서 먹을수있으니까
        if (recoverIndex >= 0 && recoverIndex < heartAnimators.Length)
        {
            heartAnimators[recoverIndex].ResetTrigger("LostHeart"); // 트리거 초기화
            heartAnimators[recoverIndex].SetTrigger("Heart"); // 복구 트리거
            //이부분은 애니메이션 파라먼트의 구조를 보면알 수 있습니다.
        }
    }

}
