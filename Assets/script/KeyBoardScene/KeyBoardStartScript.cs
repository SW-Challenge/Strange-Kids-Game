using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using Random = UnityEngine.Random;

public class KeyBoardStartScript : MonoBehaviour
{
    GameObject text;

    public void Start()
    {
        text = GameObject.Find("keyboard_text");
    }

    public void ClickButton()
    {
        gameObject.SetActive(false);
        text.SetActive(false);
    }
}
