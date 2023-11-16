using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuccessScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public TMP_Text dialogueText;
    public GameObject goPanel;

    private string[] dialogues = { //대사
        "그때 그분을 만나서 이렇게 성공할 수 있었어.", 
        "내 잘못을 깨우친 뒤에 이렇게 멋진 어른으로 자랄 수 있게 됐으니", 
        "나중에 그분을 만나면 감사하다고 말해야지"
        };

    private int currentClipIndex = 0;
    bool hasStarted = false;

    void Start()
    {
        goPanel.SetActive(false);
        Destroy(GameObject.Find("SuccessPanel"),2);  // 성공 패널 2초 뒤 제거
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
