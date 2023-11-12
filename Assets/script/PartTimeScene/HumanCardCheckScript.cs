using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using System.Text.RegularExpressions;

public class HumanCardCheckScript : MonoBehaviour
{
    GameObject product;
    GameObject say;
    GameObject human;

    // 신분증 검사 버튼을 클릭했을 경우
    public void ClickButton()
    {
        String[] sayText = { "내가 왜 내야하는데? 칫.. 자 여기! 얼른 계산이나 해!", "아니 얼굴보면 딱 모르나?", "귀찮게...", "호호~ 내가 어려보이긴 한다지만~ 흠~! 여기요~" };
        product = GameObject.Find("Product");
        say = GameObject.Find("SayText");
        human = GameObject.Find("Human");

        String sprite = product.GetComponent<SpriteRenderer>().sprite.ToString();

        // 미성년자 구입 불가 상품인 경우
        if (sprite.Equals("object1 (UnityEngine.Sprite)") || sprite.Equals("object2 (UnityEngine.Sprite)"))
        {
            // 말풍선 변경
            say.GetComponent<SayTextScript>().RandomSaid(sayText);
            
            // 신분증 꺼내기
            Invoke("HumanCardSetActive", 4.0f);

            GameObject.Find("EventSystem").GetComponent<CalCulateCheckScript1>().calY.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<BackScript>().backBtn.SetActive(true);
        }

        else
        {
            // 말풍선 변경
            String[] sayText1 = { "앗 네! 알겠습니다! ((신분증 검사가 필요한가...?", "네? 어... 알겠습니다? ((과자 사는건데 신분증 검사가 필요하다고?" };
            say.GetComponent<SayTextScript>().RandomSaid(sayText1);

            // 신분증 꺼내기
            Invoke("HumanCardSetActive", 4.0f);

            // 손님의 sprite를 가지고 동일한 신분증 꺼내기
            String humanScript = human.GetComponent<SpriteRenderer>().sprite.ToString();

            int humanScriptNumber = (int.Parse(Regex.Replace(humanScript, @"\D", "")) - 1) / 2;

            GameObject.Find("EventSystem").GetComponent<HumanCardScript>().humanCard.GetComponent<SpriteRenderer>().sprite = GameObject.Find("EventSystem").GetComponent<HumanCardScript>().sprites[humanScriptNumber];

            GameObject.Find("EventSystem").GetComponent<CalCulateCheckScript1>().calY.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<BackScript>().backBtn.SetActive(true);
        }
    }

    public void HumanCardSetActive()
    {
        GameObject.Find("EventSystem").GetComponent<HumanCardScript>().humanCard.SetActive(true);
        
    }
}
