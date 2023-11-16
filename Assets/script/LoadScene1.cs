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

        if (clearEvent.clear1 && clearEvent.clear2 && clearEvent.clear3)
        {
            GameObject.Find("EventSystem").GetComponent<EndingScript1>().SetObject();
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (clearEvent.clear1 && load == 3) return;
            else if (clearEvent.clear2 && load == 6) return;
            else if (clearEvent.clear3 && load == 5) return;
        }

        SceneManager.LoadScene(load);
    }
}
