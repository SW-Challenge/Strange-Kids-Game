using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PunchEndScript : MonoBehaviour
{
    public static void GameOver()
    {
        if (GameObject.FindObjectOfType<PunchGameScript>().gaugeBarImage.fillAmount == 0 || GameObject.FindObjectOfType<PunchGameScript>().count == 10)
        {
            GameObject.FindObjectOfType<PunchGameScript>().StopCoroutine("RandomDelayedSpawn");
        }else{
            GameObject.FindObjectOfType<PunchGameScript>().StartCoroutine("RandomDelayedSpawn");
        }
    }
}
