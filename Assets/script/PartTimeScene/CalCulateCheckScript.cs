using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class CalCulateCheckScript : MonoBehaviour
{
    GameObject say;

    public void ClickButton()
    {
        say = GameObject.Find("SayText");

        String humanScript = GameObject.Find("Human").GetComponent<SpriteRenderer>().sprite.ToString();
        int humanScriptNumber = int.Parse(Regex.Replace(humanScript, @"\D", ""));
        humanScriptNumber = humanScriptNumber % 2 == 0 ? humanScriptNumber - 1 : humanScriptNumber;

        GameObject.Find("EventSystem").GetComponent<HumanCardScript>().humanCard.SetActive(true);

        String humanCardScript = GameObject.Find("HumanCard").GetComponent<SpriteRenderer>().sprite.ToString();
        int humanCardScriptNumber = int.Parse(Regex.Replace(humanCardScript, @"\D", ""));

        GameObject.Find("EventSystem").GetComponent<HumanCardScript>().humanCard.SetActive(false);

        String productScript = GameObject.Find("Product").GetComponent<SpriteRenderer>().sprite.ToString();
        int productScriptNumber = int.Parse(Regex.Replace(productScript, @"\D", ""));

        // 신분증과 손님의 얼굴이 동일할 시 
        if (humanScriptNumber == humanCardScriptNumber || productScriptNumber == 3 || productScriptNumber == 4)
        {
            String[] sayText = { "많이 파세요!", "감사합니다~", "수고하세요~!" };
            say.GetComponent<SayTextScript>().RandomSaid(sayText);
        }

        else
        {
            String[] sayText = { "(( 이게 된다고?? ))", "(( 뭐야~ 이 편의점 다시 와야하나? ))" };
            say.GetComponent<SayTextScript>().RandomSaid(sayText);
        }

        Invoke("AgainStart", 3.0f);
    }

    void AgainStart()
    {
        GameObject.Find("Human").GetComponent<PartTimeScript>().Start();
        GameObject.Find("Product").GetComponent<PartTimeScript>().Start();
        GameObject.Find("Check").GetComponent<PartTimeScript>().Start();
        GameObject.Find("Calculate").GetComponent<PartTimeScript>().Start();
        GameObject.Find("SpeechBubble").GetComponent<PartTimeScript>().Start();
        GameObject.Find("SayText").GetComponent<SayTextScript>().Start();

        GameObject.Find("EventSystem").GetComponent<HumanCardScript>().humanCard.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<HumanCardScript>().Start();
        GameObject.Find("EventSystem").GetComponent<BackScript>().backBtn.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<BackScript>().Start();
        GameObject.Find("EventSystem").GetComponent<CalCulateCheckScript1>().calY.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<CalCulateCheckScript1>().Start();
    }
}