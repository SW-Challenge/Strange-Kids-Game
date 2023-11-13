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
    float[] doorBellSount = { 2.5f, 4.5f, 6.5f, 3.8f, 8.5f, 2.0f };
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
        Invoke("SetDoorBellSound", doorBellSount[cnt]);
    }

    void SetDoorBellSound()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        Invoke("SetActiveObject", 2.0f);
        cnt++;
    }

    void SetActiveObject()
    {
        GameObject.Find("EventSystem").GetComponent<AudioSource>().Play();
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
