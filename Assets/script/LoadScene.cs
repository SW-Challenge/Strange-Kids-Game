using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene: MonoBehaviour
{
    public void LoadGame(int load)
    {
        SceneManager.LoadScene(load);
    }
}
