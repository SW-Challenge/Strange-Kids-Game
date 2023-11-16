using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using TMPro;

public class EndingPanelScript : MonoBehaviour
{
    public GameObject endingPanel;
    int heart;

    public void Start()
    {
        endingPanel.SetActive(false);    
    }

    public void Ending()
    {
        heart = GameObject.Find("Human").GetComponent<PartTimeScript>().heart;
        GameObject.Find("SaveData").GetComponent<SaveClearData>().clear2 = true;

        if(heart == 1)
        {
            endingPanel.transform.Find("content").GetComponent<TMP_Text>().text = "휴.. 오늘은 위험했어! \n (( 신분증 확인도 없이 만 19세 미만 금지물품을 판매했다가는 경찰차가 왔을거야!ㅠ))";
        }

        else if(heart == 0)
        {
            GameObject.Find("SaveData").GetComponent<SaveClearData>().clear--;
            endingPanel.transform.Find("content").GetComponent<TMP_Text>().text = "신분증 확인 없이 만 19세 미만 금지물품을 판매해 경찰차가 왔어ㅠㅠ";
        }

        endingPanel.SetActive(true);
    }
}
