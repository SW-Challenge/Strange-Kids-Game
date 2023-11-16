using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveClearData : MonoBehaviour
{
    public bool clear1 = false;
    public bool clear2 = false;
    public bool clear3 = false;

    public int clear = 3;

    public bool loadVisible = false;

    void Awake()
    {
        var obj = FindObjectsOfType<SaveClearData>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        
        else
            Destroy(gameObject);
    }
}
