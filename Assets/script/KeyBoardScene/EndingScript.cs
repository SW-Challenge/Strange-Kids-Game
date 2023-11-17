using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using Random = UnityEngine.Random;

public class EndingScript : MonoBehaviour
{
    public GameObject panel;
    public int heart = 3;
    String text;

    void Start()
    {
        panel.SetActive(false);
    }

    public void SetActiveObject()
    {
        panel.SetActive(true);
        GameObject.Find("SaveData").GetComponent<SaveClearData>().clear3 = true;

        if(heart == 2 || heart == 1)
        {
            panel.transform.Find("content").GetComponent<TMP_Text>().text = "바르고 고운말 쓰는 모습 기대하겠습니다! \n 앞으로도 열심히 바른 국어 생활 파이팅~!";
        }
        
        else if(heart == 0)
        {
            GameObject.Find("SaveData").GetComponent<SaveClearData>().clear--;
            panel.transform.Find("content").GetComponent<TMP_Text>().text = "바르고 고운말 쓰기로 우리 약속했잖아요!ㅠ \n 지금부터라도 열심히 타자치며 글의 뜻을 이해해보아요!";
        }
    }
}
