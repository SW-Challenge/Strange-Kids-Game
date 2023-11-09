using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class PartTimeScript: MonoBehaviour
{
    public Sprite[] sprites;

    void Start()
    {
        gameObject.SetActive(false);
        Invoke("SetActiveObject", 5.0f);
    }

    void SetActiveObject()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }
}
