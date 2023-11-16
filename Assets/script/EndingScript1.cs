using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class EndingScript1 : MonoBehaviour
{
    public GameObject ending;

    void Start()
    {
        ending.SetActive(false);       
    }

    public void SetObject()
    {
        ending.SetActive(true);
    }
}
