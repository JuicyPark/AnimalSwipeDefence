# 🐶Animal Swipe Defence🐱

![0](https://user-images.githubusercontent.com/31693348/81091380-1f0c5b00-8f3a-11ea-9ef4-57be6bfa1ccc.png)



## 게임소개

**애니멀 스와이프 디펜스**는 맵 타일안에 무작위의 동물들을 생산, 이동, 합체 하여 몰려오는 적들을 섬멸하는 퍼즐 디펜스 게임입니다. 

단순히 유닛을 설치만 하는 다른 디펜스 게임들과 달리, 매 스테이지 동물들의 배치를 신경 써야하는 디펜스/퍼즐 게임입니다. 같은 동물 조합이더라도 배치에 따라 결과는 크게 갈립니다.



## 개발

- 로비

  - UI
  - 동물 뽑기
  - Sound

- 게임필드

  - UI
  - Input
    - 생산
    - 이동
  - InGame
    - 자원관리
    - 전투
    - 재배치
  - Sound

  



## 개발 상세 내용

#### (🙀해당부분은 리펙토링 레파지토리에서 진행한 작업임🙀)

**Managers**

![1](https://user-images.githubusercontent.com/31693348/81091324-08660400-8f3a-11ea-9f4c-0d1987a90b1e.png)

[delegate Action을 이용한 Manager간 의존성 완화](https://github.com/JuicyPark/ASD_Refactoring/tree/develop/Assets/Scripts/Manager)

GameManager가 다양한 Manager에서 발생하는 이벤트들을 서로 매핑시켜주어 Manager간 의존을 낮춤



**Stage Data**

![2](https://user-images.githubusercontent.com/31693348/81091360-14ea5c80-8f3a-11ea-933b-19aa11757878.png)

[ScriptableObject를 이용하여 Stage 생성](https://github.com/JuicyPark/ASD_Refactoring/blob/develop/Assets/Scripts/Data/EnemyData.cs)

스테이지들을  ScriptableObject로 만들어 두어 수정 및 관리가 용이합니다. 이 데이터들은 StageManager에서 해당 레벨에 맞는 Stage Enemy들을 불러와줍니다.



**Unit, Enemy**

![6](https://user-images.githubusercontent.com/31693348/81091402-27649600-8f3a-11ea-9bd5-34b3e390a029.png)

[플레이어가 생성하는 Unit](https://github.com/JuicyPark/ASD_Refactoring/blob/develop/Assets/Scripts/Unit.cs)

[스테이지에 등장하는 Enemy](https://github.com/JuicyPark/ASD_Refactoring/blob/develop/Assets/Scripts/Enemy.cs)
