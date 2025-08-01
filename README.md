오마주게임 - 쿠키런
-
1차 팀회의 - 역할 분배 및 컨셉정하기
-

1.플레이어 캐릭터 생성 및 움직임과 점프 슬라이딩 구현하기
-
Input.GetKey 와 InPut.GetMouse를 통해 키보드값과 마우스값을 받아오게작성
if조건문을 사용해 애니메이터의 활성화 비활성화를 구현
점프는 최대 2회 JumpCount , MaxJumpCount라는 변수를 이용해 조건문을 사용하여 구현
Physics2D.OverlapCircle를 사용해 ridious(반지름)가 Ground에 닿았을때 JumpCount를 초기화

2.카메라가 플레이어를 따라가게 만들기
-
Transform.position을 플레이어를 따라가도록 구현 + offset을 통해 카메라와 플레이어간의 거리를 조절

3.BackGround와Ground프리펩을 통해 배경을 구현
-
BackGround , Ground 스프라이트를 활용해 프리펩을 만들고 묶어서 맵을 구현했습니다

4.BgLooper를 통해 맵을 루프시키기
-
BgLooper라는 가상의 막대를 통해 맵과 충돌시 맵의 끝으로 이동하여 맵이 루프되도록 구현했습니다.

5.점프 오디오 재생
-
Audio Manager를 생성 Audio Souce 컴퍼넌트를 붙이고 배열을 사용해 오디오클립을 생성 후 플레이원샷해서 한번만재생
후에 플레이어스크립트에 오디오매니저를 넘겨서 점프카운트와 연동시키고 각기 다른 점프사운드를 재생하게 구현했습니다.

6.애니메이션
-
벌이 날아다니는 코드를짜려다 너무 복잡하고 어려워서 애니매이션으로 편하고 빠르게 구현(애니메이션에 포지션변경활용)
애니메이션으로 움직음을 제어하다보니 부모가 필요해서 Bee를 realBee의 자식으로 넣어놓았습니다.
그러다보니 GetComponent가 아닌 GetComponentInparet를 써야한다는걸 알았습니다.

7.점수저장
-
점수저장을 위해 PlayerPrefs.SetInt("Score"(GetInt에서 가져올 키코드임),score(점수값 우리코드에서는 int score였음))를 사용해 점수를 넣어놓고
PlayerPrefs.Save();로 저장했습니다.
그리고 불러올 씬으로 넘어가서 새로운 스크립트EndScore를 생성후 스코어(텍스트매쉬프로)에 붙여줬습니다.
그 후 유니티엔진.UI를 불러오고 public TextMeshProUGUI를 생성 후
스타트에 int LoadedScore = PlayerPrefs.GetInt("Score"(SetInt에서 썻던 키코드임),0(기본값임)) 으로 저장한 점수값을 불러오고
 scoreText.text = LoadedScore.ToString(); 를 통해 글자로 표현했습니다.
 쓰고나니 진짜 간단한 코드였는데 생각보다 이해하는데 시간이 많이 걸렸습니다.


깃허브 잘못써서 터질뻔
