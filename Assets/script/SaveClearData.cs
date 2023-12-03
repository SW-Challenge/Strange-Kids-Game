using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using TMPro;

public class SaveClearData : MonoBehaviour
{
    public bool clear1 = false;
    public bool clear2 = false;
    public bool clear3 = false;

    public int clear = 3;

    public bool loadVisible = false;

    void Awake()
    {
        // 변수 초기화
        clear1 = false;
        clear2 = false;
        clear3 = false;
        clear = 3;
        loadVisible = false;
        
        var obj = FindObjectsOfType<SaveClearData>();
        
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject);
    }
}
