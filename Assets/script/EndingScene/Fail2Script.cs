using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fail2Script : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public TMP_Text dialogueText;
    public GameObject goPanel;

    private string[] dialogues = { //대사
        "아~ 티비 볼 거 없나?", 
        "이제 슬슬 게임이나 해야겠다.", 
        "꼬르륵", 
        "엄마~ 밥 언제 되냐고!",
        "엄마는 밥도 제때 안 해주고 뭐 하는 거야...",
        "아... 진짜 내가 취업만 하면 이 망할 집구석 당장 나간다."
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
            goPanel.SetActive(true);
        }
    }

}
