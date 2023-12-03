using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fail1Script : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public TMP_Text dialogueText;
    public GameObject goPanel;

    private string[] dialogues = { //대사
        "오늘도 팀장한테 욕만 들었네...", 
        "매일매일이 힘들어", 
        "이런 회사 당장이라도 때려치우고 싶지만...", 
        "어렸을 때 공부도 하고 주변 사람들한테 잘했더라면\n지금보다 나아질 수 있었겠지?"
        };

    private int currentClipIndex = 0;
    bool hasStarted = false;

    void Start()
    {
        goPanel.SetActive(false);
        Destroy(GameObject.Find("FailPanel"),2);  // 실패 패널 2초 뒤 제거
        Invoke("PlayNextClip", 2f);
    }

    void Update()
    {
        if (hasStarted && !audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        hasStarted = true;
        if (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            dialogueText.text = dialogues[currentClipIndex];  //대사
            audioSource.Play();  //재생
            currentClipIndex++;
        }
        else
        {
            GameObject.Find("SaveData").GetComponent<SaveClearData>().clear1 = false;
            GameObject.Find("SaveData").GetComponent<SaveClearData>().clear2 = false;
            GameObject.Find("SaveData").GetComponent<SaveClearData>().clear3 = false;
            GameObject.Find("SaveData").GetComponent<SaveClearData>().clear = 3;

            goPanel.SetActive(true);
        }
    }


}
