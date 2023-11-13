using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PunchGameScript : MonoBehaviour
{
    public TMP_Text keyText;  // 랜덤키를 텍스트
    public GameObject fist;   // 주먹 오브젝트
    public GameObject fistOutline;  // 주먹 판정선 오브젝트
    public GameObject howToPlayPanel;  // 게임 방법 패널
    public GameObject gaugeBar;  // 체력바
    public Image gaugeBarImage;  // 체력바 이미지
    public TMP_Text bubbleText;  // 잼민이 말풍선 대사
    public GameObject jemminAni;  //잼민이 애니메이션
    public GameObject jemmin;  //잼민이
    KeyCode randomKey;  // 랜덤으로 선택된 키를 저장할 변수
    public int count = 0;  // 주먹 몇 번 생성됐는지

    AudioSource audioSource;
    public AudioClip punchSound;

    // 게임 시작 함수
    public void GameStart()
    {
        jemmin.SetActive(false);  //잼민이 비활성화
        jemminAni.SetActive(true);  //잼민이 애니메이션 활성화
        audioSource = GetComponent<AudioSource>();
        howToPlayPanel.SetActive(false);  // 게임방법 패널 비활성화
        gaugeBar.SetActive(true);  // 체력바 활성화
        bubbleText.text = "어디 한 번 막아보시지!";  // 말풍선 대사 설정
        StartCoroutine(RandomDelayedSpawn());  // 랜덤 딜레이 후 주먹 생성 코루틴 시작
    }

    // 성공
    void Pass()
    {
        bubbleText.text = "오; 꽤 하는데?";
        Debug.Log(randomKey + " : 성공");
        Check();
    }

    void Check(){
        fist.SetActive(false);  // 주먹 활성화
        fistOutline.SetActive(false);  // 주먹 판정선 활성화
        PunchEndScript.GameOver();
    }

    // 실패
    void Fail()
    {
        Debug.Log(randomKey + " : 실패");
        bubbleText.text = "슈슈슉슈슉ㅋㅋ 못 막았쥬?";
        gaugeBarImage.fillAmount -= 0.1f;  // 체력 감소
        Check();
    }

    // 랜덤 딜레이 후 주먹 생성 코루틴
    IEnumerator RandomDelayedSpawn()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));  // 1초에서 5초 사이의 랜덤한 시간 딜레이
        SpawnFist();  // 주먹 생성
        fist.SetActive(true);  // 주먹 활성화
        fistOutline.SetActive(true);  // 주먹 판정선 활성화
    }

    // 주먹 판정선 줄어드는 애니메이션 함수
    IEnumerator ScaleAnimation()
    {
        float targetScale = 47f;
        float startScale = fistOutline.transform.localScale.x;
        float speed = 30f;  // 일정 속도

        while (fistOutline.transform.localScale.x > targetScale)
        {
            float currentScale = fistOutline.transform.localScale.x;
            float newScale = currentScale - speed * Time.deltaTime;

            if (newScale < targetScale)
                newScale = targetScale;

            fistOutline.transform.localScale = new Vector3(newScale, newScale, 1f);

            // 주먹 판정선이 주먹과 안맞으면 실패
            if (Input.GetKeyDown(randomKey) && newScale <= 54 && newScale >= 47f)
            {
                audioSource.PlayOneShot(punchSound);
                Pass();  // 성공
                yield break;
            }
            else if(Input.anyKeyDown || newScale == 47f)
            {
                audioSource.PlayOneShot(punchSound);
                Fail();  // 실패
                yield break;
            }
            yield return null;
        }
    }

    // 주먹 생성 함수
    void SpawnFist()
    {
        count++;

        // 랜덤 키
        char randomChar = (char)Random.Range('A', 'Z' + 1);
        randomKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), randomChar.ToString());

        // 랜덤 위치 설정
        Vector3 randomPosition = GetRandomPosition();
        // 주먹 위치 설정
        fist.transform.position = randomPosition;
        // 키 텍스트 설정
        keyText.text = randomKey.ToString();

        // 주먹 판정선 크기 초기화
        fistOutline.transform.localScale = new Vector3(80f, 80f, 1f);
        // 주먹 판정선 위치 설정
        fistOutline.transform.position = fist.GetComponent<Renderer>().bounds.center;
        // fistOutline.transform.position = randomPosition;
        StartCoroutine(ScaleAnimation());
    }

    // 랜덤 위치 생성 함수
    Vector3 GetRandomPosition()
    {
        float x = Random.Range(Screen.width * 0.1f, Screen.width * 0.9f);
        float y = Random.Range(Screen.height * 0.2f, Screen.height * 0.6f);
        return new Vector3(x, y, 1f);
    }
}
