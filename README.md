
### DAON Metaverse Unity Project
![image](https://user-images.githubusercontent.com/54030889/185741419-35f34f4b-8398-4113-8309-07916f03169b.png)

---

![](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/176fc804-93da-4eab-b6c8-5aaa3b74951f/Main_Logo.jpg)

**냉장고동 행복센터**는 유저들이 과일 캐릭터로 2D 기반 **메타버스** 플랫폼입니다.

**인공지능**을 이용하여 **개인의 취향과 비슷한 사람**들을 찾아서 매칭을 시켜줍니다.

## 🤔How To Use?

---

1. 행복센터로 들어간다.**(로그인)**
2. 회원가입을 하고 자신의 취향에 대한 설문조사를 실시한다.
3. 자신이 나누고 싶은 카테고리가 정해진 방으로 이동한다.
  로비  ![image](https://user-images.githubusercontent.com/54030889/185741432-2c0229ed-87de-406e-94a3-e314a28e0c77.png)


    1) 음악 방에 들어가서 채팅창을 통해 자유롭게 소통하고, + 버튼을 눌러서 노래를 신청하고 나가기 버튼을 누르면 로비로 돌아온다.

    2) 영화 방에 들어가서 채팅창을 통해 소통하고 + 버튼으로 추천하고 싶은 영화를 추가하고 사람들과 공유할 수 있다. 나가기 버튼을 누르면 로비로 돌아올 수 있다.
    ![image](https://user-images.githubusercontent.com/54030889/185741442-85f9da3f-7560-47ee-ac00-7aac39f9efb5.png)


## ⚒️ Stack ⚒️

---

### 인공지능 추천 알고리즘

**1) 데이터셋 :**

자료의 확률을 기반으로 랜덤으로 데이터 추출해서 10000개의 데이터셋 생성.

※ 2018년 한국인이 선호하는 영화장르 출처

Ref : [http://catalk.kr/culture/favorite-movie-genres-in-south-korea.html](http://catalk.kr/culture/favorite-movie-genres-in-south-korea.html)

2) **AE ( AutoEncoder )** : **Latency Vector** 추출해서 학습 데이터로 활용

AutoEncoder의 Embeding Process에서 feature로 데이터셋의 feature를 잘 잡아냄.

**Ref : [https://deepinsight.tistory.com/126](https://deepinsight.tistory.com/126)**

**2) Linear Model :** 선형 학습

단일 신경망을 선형적으로 연결하여 학습을 실시했다.

**Reference : [https://www.sciencedirect.com/topics/mathematics/linear-models](https://www.sciencedirect.com/topics/mathematics/linear-models)**

**3) Cosine Similarity :**  내적공간의 두 벡터간 각도의 코사인값을 이용하여 측정된 벡터간의 유사한 정도를 의미한다. 즉, 다른 취향을 기록한 데이터 값의 유사한 정도를 측정할 수 있다.

위 결과는 2개의 다른 장르의 유사도를 계산한 것이다. 값이 1에 수렴할수록 유사하다고 할 수 있다.


이 값에 근거하여 유저들 간의 취향을 분석하여 매칭을 실시한다.

**Ref : [https://www.sciencedirect.com/topics/computer-science/cosine-similarity](https://www.sciencedirect.com/topics/computer-science/cosine-similarity)**

**4) Unity**

**1) Photon :** **Unity Asset**을 이용하여 **Server**를 구축하고, Unity Asset인

**Photon PUN** 를 이용하여 가상공간을 생성하여, 유저들이 사용할 수 있는 개별적인 소통공간을 생성했다.

**2) Unity :** 2차원 캐릭터 구현및 알고리즘을 구현하는 **Component, C# Script** 기반 프로그램을 이용해서 전체 **UI (User Interface)**를 구현했다.

---

### ▶️Using Asset

---

[Photon Unity Networking Classic - FREE | Network | Unity Asset Store](https://assetstore.unity.com/packages/tools/network/photon-unity-networking-classic-free-1786)

[City Pack - Top Down - Pixel Art | 2D Textures & Materials | Unity Asset Store](https://assetstore.unity.com/packages/2d/textures-materials/city-pack-top-down-pixel-art-195403)

[Photon Chat | Network | Unity Asset Store](https://assetstore.unity.com/packages/tools/network/photon-chat-45334)

## 기대효과

---

- **COVID-19**로 인한 언택트 사회에 **MZ세대**들에게 다양한 문화생활 소통공간을 온라인에서 제공할 수 있음.

- **경량화 인공지능 모델**을 사용하여 성능이 좋은 컴퓨터를 가지고 있지 않은 유저도 가볍게 매칭프로그램을 이용할 수 있다. 이를 통해 자신과 유사한 취미를 가지고 있는 사람과 취미활동을 공유할 수 있어진다.

- 기존의 서비스와 달리, 컨텐츠 카테고리 세부화를 통해 자신과 취향이 비슷한 사용자들을 찾고 친해지기 쉬워지기 때문에 이에 필요한 기회비용을 줄일 수 있다.
