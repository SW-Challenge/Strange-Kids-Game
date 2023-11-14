using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using Random = UnityEngine.Random;
using System.Runtime.ExceptionServices;

public class TypingSpeed : MonoBehaviour
{
    public TMP_InputField userInputField;
    public TMP_Text speedDisplay;
    public TMP_Text maxSpeedDisplay;
    public string targetText = "Type this sentence!"; // 변경 가능한 문장

    private float startTime;
    private float maxSpeed = 0f;
    private int totalChars = 0;
    private int errors = 0;
    private const int errorPenalty = 50;
    private const float decayRate = 0.001f;
    private const float updateInterval = 0.5f;
    private float lastUpdateTime = 0f;
    private int cnt = 0;

    int heart = 3;

    String updateText;

    String[] text = {
        "너를 만난 건 천운이야. 완벽한 타이밍에 널 만나게 되서 기뻐",
"너를 사랑하듯 모두를 그리 볼 수 있다면 세상을 사랑하기 정말 쉬울 거야.",
"내가 너를 사랑하고 보는 것처럼 너도 너를 그렇게 봐줬으면 좋겠어.",
"당신 그대로 살아줘서 고마워요.",
"지금 힘드신 거 지나가는 구름입니다.",
"살아가면서 너무 늦거나, 이른 건 없고, 꿈을 이루는 데 제한시간은 없다.",
"꿈은 도망가지 않아, 도망가는 건 언제나 자기 자신이지.",
"누구나 재능은 있다. 드문 것은 그 재능이 이끄는 암흑 속으로 따라 들어갈 용기다.",
"계획은 무슨! 계획대로 안되는 게 인생이란거야.",
"너의 길을 가라. 남들이 무엇이라 하든지. 내버려두라.",
"모든 시련은 결국에는 축복이 되기 마련이다.",
"웃음은 전염된다. 웃음은 감염된다. 이 둘은 당신의 건강에 좋다.",
"아무것도 시도할 용기를 각지 못한다면 인생은 대체 무엇이겠는가?",
"미래는 자신이 가진 꿈의 아름다움을 믿는 자의 것이다.",
"나는 내가 더 노력할수록 운이 더 좋아진다는 걸 발견했다.",
"사랑은 인생에서 가장 훌륭한 치유제다.",
"우리의 인생은 우리가 노력한 만큼 가치가 있다.",
"믿음은 산산이 조각난 세상을 빛으로 나오게 하는 힘이다.",
"우연이 아닌 선택이 운명을 결정한다.",
"남을 행복하게 하는 것은 향수를 뿌리는 것과 같다. 뿌릴 때 자기에게도 몇 방울 정도는 묻기 때문이다.",
"강인하고 긍정적인 태도는 그 어떤 특효약보다 더 많은 기적을 만들어 낸다.",
"낭비한 시간에 대한 후회는 더 큰 시간의 낭비이다.",
"지금 최선을 다하면 미래는 알아서 잘 풀릴 것이다.",
"인생의 목적과 그것을 성취하는 방법을 깨닫는 것, 그것이 바로 지혜다.",
"행복은 밖에서 오지 않는다. 행복은 우리들 마음속에서 우러난다.",
"행복이란 삶의 의미이자 목적이요, 인간 존재의 총체적 목표이자 끝이다.",
"인생의 흐름을 지켜보지 말고 그 속에 뛰어들어라.",
"용기란 자신이 두려워하는 것을 하는 것이다. 즉 두려움이 없으면 용기도 없다."
    };

    void Start()
    {
        targetText = text[cnt];
        GameObject.Find("game_input").GetComponent<TMP_Text>().text = targetText;
        userInputField.text = ""; // 사용자 입력 필드 비움
        userInputField.Select(); // 사용자 입력 필드 선택
        speedDisplay.text = "0"; // 초기 타자 속도 표시
        maxSpeedDisplay.text = "0"; // 초기 최고 타자 속도 표시
        startTime = Time.time; // 시작 시간 기록
    }

    void Update()
    {

        float totalTime = Time.time - startTime; // 총 걸린 시간 계산
        float deltaTime = Time.time - lastUpdateTime;

        if (deltaTime > updateInterval)
        {
            lastUpdateTime = Time.time;

            if (userInputField.text.Length > totalChars && userInputField.text.Length <= targetText.Length)
            {
                totalChars = userInputField.text.Length;
                float charsPerMinute = CalculateCPM(totalChars, totalTime);
                speedDisplay.text = Mathf.Max(Mathf.RoundToInt(charsPerMinute), 0) + ""; // CPM 표시

                if (charsPerMinute > maxSpeed)
                {
                    maxSpeed = charsPerMinute;
                    maxSpeedDisplay.text = Mathf.Max(Mathf.RoundToInt(maxSpeed), 0) + ""; // 최고 CPM 표시
                }
            }
        }

        if (totalTime > 0)
        {
            totalChars -= (int)(decayRate * totalTime); // 시간에 따라 CPM 점차적으로 감소
            totalChars = Mathf.Max(totalChars, 0); // 음수 방지
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (userInputField.text.Length >= targetText.Length)
            {
                /*if(cnt == 27)
                {
                    GameObject.Find("EventSystem").GetComponent<EndingScript>().SetActiveObject();
                }

                if (userInputField.text != targetText)
                {
                    heart = GameObject.Find("EventSystem").GetComponent<EndingScript>().heart;
                    heart--;

                    GameObject.Find("EventSystem").GetComponent<EndingScript>().heart = heart;
                }*/

                cnt++;
                targetText = text[cnt];
                GameObject.Find("game_input").GetComponent<TMP_Text>().text = targetText;
                userInputField.text = "";
                userInputField.Select();
                userInputField.ActivateInputField();
                startTime = Time.time;
                totalChars = 0;
                errors = 0;
            }
        }

        if (userInputField.text.Length <= targetText.Length)
        {
            for (int i = 0; i < userInputField.text.Length; i++)
            {
                if (userInputField.text[i] == targetText[i])
                {
                    SetTextColor(i, Color.black);
                }
                
                else
                {
                    SetTextColor(i, Color.red);
                }

                GameObject.Find("game_input").GetComponent<TMP_Text>().text = updateText;
            }
        }
    }

    void SetTextColor(int index, Color color)
    {
        updateText = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{targetText[index]}</color>" + targetText.Substring(index + 1);
    }

    float CalculateCPM(int characters, float time)
    {
        float adjustedChars = characters - (errors * errorPenalty);
        float charsPerMinute = adjustedChars / (time / 60);
        return charsPerMinute + 200;
    }
}
