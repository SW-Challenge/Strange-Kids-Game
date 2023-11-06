using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene: MonoBehaviour
{
    public void LoadGame()
    {
        
        SceneManager.LoadScene(1);
        UnityEngine.Debug.Log("loadgame");
    }
}
