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

깃허브 잘못써서 터질뻔

아이템 잼에 Enum을 줘서 배열로 하여 여러 잼과 아이템구현하기

만들어진 오디오매니저를 통해 배경음악을 넣기
->오디오 매니저 수정한점 효과음과 배경음으로 분류함 오디오클립에서

 배경음악 출처:
"Happy Adventure" by Fesliyan Studios  
https://www.fesliyanstudios.com/play-music/6393
“Free License with Attribution”

