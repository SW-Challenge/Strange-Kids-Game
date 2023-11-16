using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using TMPro;

public class LoadScene1 : MonoBehaviour
{
    SaveClearData clearEvent;

    public void LoadGame(int load)
    {
        clearEvent = GameObject.Find("SaveData").GetComponent<SaveClearData>();

        Debug.Log(clearEvent.clear1);
        Debug.Log(clearEvent.clear2);
        Debug.Log(clearEvent.clear3);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (clearEvent.clear1 && load == 3) return;
            else if (clearEvent.clear2 && load == 6) return;
            else if (clearEvent.clear3 && load == 5) return;
        }

        SceneManager.LoadScene(load);
    }
}
