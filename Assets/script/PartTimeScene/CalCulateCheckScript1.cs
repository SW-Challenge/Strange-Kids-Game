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

public class CalCulateCheckScript1 : MonoBehaviour
{
    public GameObject calY;
    GameObject say;
    
    public void Start()
    {
        calY = GameObject.Find("Calculate_Y");
        calY.SetActive(false);
        say = GameObject.Find("SayText");
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
            String[] sayText = { "많이 파세요!", "감사합니다~", "수고하세요~!" };
            say.GetComponent<SayTextScript>().RandomSaid(sayText);
        }

        else
        {
            String[] sayText = { "(( 이게 된다고?? ))", "(( 뭐야~ 이 편의점 다시 와야하나? ))" };
            say.GetComponent<SayTextScript>().RandomSaid(sayText);
            GameObject.Find("Human").GetComponent<PartTimeScript>().heart--;
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

        GameObject.Find("EventSystem").GetComponent<HumanCardScript>().Start();
        GameObject.Find("EventSystem").GetComponent<BackScript>().Start();
        Start();
    }
}
