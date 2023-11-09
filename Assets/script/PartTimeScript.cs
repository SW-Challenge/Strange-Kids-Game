using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class PartTimeScript: MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("SetActiveObject", 5.0f);
    }

    void SetActiveObject()
    {
        gameObject.SetActive(true);
    }
}
