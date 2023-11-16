using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using Random = UnityEngine.Random;

public class ArrowScript : MonoBehaviour
{
    public GameObject arrow;
    float bulletSpeed = 10f; // ÃÑ¾Ë ¼Óµµ
    float x = -764.8f, y = -68.5f;

    void Start()
    {
        arrow.SetActive(false);
    }

    void Update()
    {
        arrow.transform.Translate(Vector2.right * (bulletSpeed * Time.deltaTime + 5));
    }

    public void Arrow()
    {
        arrow.SetActive(true);
        arrow.transform.localPosition = new Vector3(x, y, 1f);
    }
}
