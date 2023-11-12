using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class HumanCardScript : MonoBehaviour
{
    public GameObject humanCard;
    public Sprite[] sprites;
    float[] time = { 7.0f, 10.0f, 15.0f, 11.3f, 12.3f, 19.3f };

    public void Start()
    {
        humanCard.SetActive(false);
        SetRandomObject();
    }

    // 랜덤 오브젝트 이미지 set
    public void SetRandomObject()
    {
        var random = Random.Range(0, sprites.Length - 1);
        humanCard.GetComponent<SpriteRenderer>().sprite = sprites[random];
    }
}
