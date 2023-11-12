using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class PartTimeScript : MonoBehaviour
{
    public Sprite[] sprites;
    float[] time = { 4.0f, 6.0f, 8.0f, 5.3f, 12.0f, 3.5f };
    int cnt = 0;

    public int heart = 2;

    GameObject say;
    String[] sayText = { "계산해", "계산해주세요!", "여기요~", "여기", "얼른 계산안해?", "..." };

    public void Start()
    {
        if (heart == 0 || cnt == 6) GameObject.Find("EventSystem").GetComponent<LoadScene1>().LoadGame(1);

        say = GameObject.Find("SayText");
        gameObject.SetActive(false);
        SetTimeAfter();
    }

    public void SetTimeAfter()
    {
        Invoke("SetActiveObject", time[cnt]);
        Debug.Log(cnt);
        cnt++;
        Debug.Log(cnt);
    }

    void SetActiveObject()
    {
        gameObject.SetActive(true);
        SetRandomObject(); 
        say.GetComponent<SayTextScript>().RandomSaid(sayText);
    }

    // 랜덤 오브젝트 이미지 set
    public void SetRandomObject()
    {
        var random = Random.Range(0, sprites.Length - 1);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[random];
    }
}
