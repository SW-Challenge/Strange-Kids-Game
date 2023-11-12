using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PunchEndScript : MonoBehaviour
{
    public static GameObject endPanel;  //게임종료 패널
    public static TMP_Text content;

    public void Awake()
    {
        endPanel = GameObject.Find("EndPanel");
        content = GameObject.Find("content").GetComponent<TMP_Text>();
        endPanel.SetActive(false);
    }

    public static void GameOver()
    {
        //주먹막기를 10번 했거나 게이지가 0이 되면 게임 종료
        if (GameObject.FindObjectOfType<PunchGameScript>().gaugeBarImage.fillAmount == 0 || GameObject.FindObjectOfType<PunchGameScript>().count == 10)
        {
            GameObject.FindObjectOfType<PunchGameScript>().StopCoroutine("RandomDelayedSpawn");
            GameObject.FindObjectOfType<PunchGameScript>().gaugeBar.SetActive(false);  // 게이지바 안 보이게

            if(GameObject.FindObjectOfType<PunchGameScript>().gaugeBarImage.fillAmount != 0){
                content.text = "휴.. 잼민이의 주먹을 잘 피했다.\n잼민이도 앞으로 또 이러진 않겠지?";
            }else{
                content.text = "내가 어린애한테 지다니...";
            }

            endPanel.SetActive(true);
        }else{
            GameObject.FindObjectOfType<PunchGameScript>().StartCoroutine("RandomDelayedSpawn");
        }
    }
}
