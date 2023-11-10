using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PunchGameScript : MonoBehaviour
{
    public TMP_Text keyText; // 랜덤으로 선택된 키를 표시할 텍스트
    public GameObject fist; // 주먹
    public GameObject howToPlayPanel;  //게임 방법 패널
    public GameObject gaugeBar;  //체력바
    public TMP_Text bubbleText;  //잼민이 말풍선 대사

    private KeyCode randomKey; // 랜덤으로 선택된 키를 저장할 변수
    private float timer = 3f; // 주어진 시간(3초) 내에 키를 눌러야 함
    private bool isStart = false;  //게임 시작했나 안했나

    public void gameStart()
    {
        howToPlayPanel.SetActive(false);  //게임방법 패널 안 보이게
        gaugeBar.SetActive(true);  //게이지바 보이게
        bubbleText.text = "어디 한 번 막아보시지!";
        isStart = true;  //게임 시작
        fist.SetActive(true);  //주먹 보이게
        SpawnFist(); // 게임 시작 시 주먹 생성
    }

    void Update()
    {
        if (isStart)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                Fail();
            }
            CheckInput();
        }
    }

    // 랜덤으로 주먹을 생성하는 함수
    void SpawnFist()
    {
        char randomChar = (char)Random.Range('A', 'Z' + 1);
        randomKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), randomChar.ToString());

        // 랜덤한 위치 계산
        float x = Random.Range(Screen.width * 0.1f, Screen.width * 0.9f);
        float y = Random.Range(Screen.height * 0.2f, Screen.height * 0.6f);

        Vector3 randomPosition = new Vector3(x, y, 0f);

        // 주먹 위치 지정
        fist.transform.position = randomPosition;
        //키 텍스트 설정
        keyText.text = randomKey.ToString();
        timer = 3f; // 타이머 재설정
    }

    // 입력된 키를 확인하는 함수
    void CheckInput()
    {
        if (Input.GetKeyDown(randomKey))
        {
            Pass(); // 정확한 키를 눌렀을 때
        }
    }

    void Pass()  //막기 성공
    {
        Debug.Log("성공!");
        SpawnFist(); // 새로운 주먹 생성
    }

    void Fail()  //막기 실패
    {

    }
}
