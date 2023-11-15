using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using Random = UnityEngine.Random;

public class FireScript : MonoBehaviour
{
    public GameObject fire;
    public float bulletSpeed = 10f; // ÃÑ¾Ë ¼Óµµ
    float x = 782.0f, y = -53.0f;

    void Start()
    {
        InvokeRepeating("Fire", 3f, 8f);
    }

    void Update()
    {
        fire.transform.Translate(Vector2.left * (bulletSpeed * Time.deltaTime + 5));
    }

    void Fire()
    {
        fire.transform.localPosition = new Vector3(x, y, 1f);
        Debug.Log(fire.transform.position);
    }
}
