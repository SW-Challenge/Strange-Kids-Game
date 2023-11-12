using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PunchPrologue : MonoBehaviour
{
    public TMP_Text bubbleText;  //잼민이 말풍선 대사
    public GameObject howToPlayPanel;  //게임 방법 패널
    public GameObject gaugeBar;  //체력바
    int clickCount;
    
    // Start is called before the first frame update
    void Start()
    {
        gaugeBar.SetActive(false);  //체력바 안 보이게
        howToPlayPanel.SetActive(false);  //게임 방법 패널 안 보이게
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) || Input.touchCount>0){  //클릭 카운트
            clickCount++;
        }
        
        if(clickCount == 0){
            bubbleText.text = "아!";
        }else if(clickCount == 1){
            bubbleText.text = "아 씨...";
        }else if(clickCount == 2){
            bubbleText.text = "아저씨! 사람을 쳤으면 사과를 해야죠~";
        }else if(clickCount == 3){
            bubbleText.text = "제가 먼저 쳤다고요?";
        }else if(clickCount == 4){
            bubbleText.text = "아... 이 아저씨 안되겠네...";
        }else if(clickCount == 5){
            bubbleText.text = "주먹은 안쓰기로 여친이랑 약속했는데...";
        }else if(clickCount == 6){
            howToPlayPanel.SetActive(true);  //게임방법 패널 보이게
        }
    }
}
