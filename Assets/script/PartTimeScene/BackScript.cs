using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using Random = UnityEngine.Random;
using System.Text.RegularExpressions;

public class BackScript : MonoBehaviour
{
    public GameObject back;
    GameObject say;

    public void Start()
    {
        back = GameObject.Find("Back");
        say = GameObject.Find("SayText");
        back.SetActive(false);
    }

    public void ClickButton()
    {
        String humanScript = GameObject.Find("Human").GetComponent<SpriteRenderer>().sprite.ToString();
        int humanScriptNumber = int.Parse(Regex.Replace(humanScript, @"\D", ""));
        humanScriptNumber = humanScriptNumber % 2 == 0 ? humanScriptNumber - 1 : humanScriptNumber;

        String humanCardScript = GameObject.Find("HumanCard").GetComponent<SpriteRenderer>().sprite.ToString();
        int humanCardScriptNumber = int.Parse(Regex.Replace(humanCardScript, @"\D", ""));

        Debug.Log(humanCardScriptNumber + " " + humanScriptNumber);

        // 신분증과 손님의 얼굴이 동일할 시 
        if (humanScriptNumber == humanCardScriptNumber)
        {
            String[] sayText = { "네? 제 얼굴 똑같지 않나요? 왜...", "전 과자를 샀는데 안된다고 하시면...", "...?" };
            say.GetComponent<SayTextScript>().RandomSaid(sayText);
        }

        else
        {
            String[] sayText = { "칫...", "아니 어딜봐도 내 얼굴인데 왜?", "이 편의점 다시는 안와!" };
            say.GetComponent<SayTextScript>().RandomSaid(sayText);
        }

        Invoke("AgainStart", 5.0f);
    }

    void AgainStart()
    {
        GameObject.Find("Human").GetComponent<PartTimeScript>().Start();
        GameObject.Find("Product").GetComponent<PartTimeScript>().Start();
        GameObject.Find("Check").GetComponent<PartTimeScript>().Start();
        GameObject.Find("Calculate").GetComponent<PartTimeScript>().Start();
        GameObject.Find("SpeechBubble").GetComponent<PartTimeScript>().Start();
        GameObject.Find("SayText").GetComponent<SayTextScript>().Start();

        GameObject.Find("EventSystem").GetComponent<HumanCardScript>().Start();
        GameObject.Find("EventSystem").GetComponent<CalCulateCheckScript1>().Start();
        Start();
    }
}
