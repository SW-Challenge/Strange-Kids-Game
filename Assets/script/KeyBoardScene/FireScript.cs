using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using TMPro;
using Random = UnityEngine.Random;
using System.Runtime.ExceptionServices;

public class FireScript : MonoBehaviour
{
    float bulletSpeed = 10f; // ÃÑ¾Ë ¼Óµµ
    float x = 782.0f, y = -53.0f;

    void Start()
    {
        gameObject.SetActive(false);
        InvokeRepeating("Fire", 15f, 15f);
    }

    void Update()
    {
        gameObject.transform.Translate(Vector2.left * (bulletSpeed * Time.deltaTime + 5));
    }

    void Fire()
    {
        gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector3(x, y, 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);

        if (other.gameObject.name.Equals("arrow"))
        {
            other.gameObject.SetActive(false);
        }

        else
        {
            GameObject.Find("EventSystem").GetComponent<EndingScript>().heart--;

            if (GameObject.Find("EventSystem").GetComponent<EndingScript>().heart == 2)
            {
                GameObject.Find("heart (2)").SetActive(false);
            }

            else if (GameObject.Find("EventSystem").GetComponent<EndingScript>().heart == 1)
            {
                GameObject.Find("heart (1)").SetActive(false);
            }

            else
            {
                GameObject.Find("heart").SetActive(false);
                GameObject.Find("EventSystem").GetComponent<EndingScript>().SetActiveObject();
            }
        }
    }
}
