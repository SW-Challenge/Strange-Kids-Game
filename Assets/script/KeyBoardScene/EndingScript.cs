using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using Random = UnityEngine.Random;

public class EndingScript : MonoBehaviour
{
    public GameObject panel;
    int heart = 3;

    void Start()
    {
        panel.SetActive(false);
    }

    public void SetActiveObject()
    {
        panel.SetActive(true);
    }
}
