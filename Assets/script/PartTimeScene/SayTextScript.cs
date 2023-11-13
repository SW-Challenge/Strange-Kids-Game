using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class SayTextScript : MonoBehaviour
{
    public void Start()
    {
        GetComponent<TMP_Text>().text = "";
    }

    public void RandomSaid(String[] say)
    {
        var random = Random.Range(0, say.Length - 1);
        GetComponent<TMP_Text>().text = say[random];
    }
}
