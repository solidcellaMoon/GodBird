using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dailyEvent : MonoBehaviour
{
    public Text eventTxt, content;
    // Start is called before the first frame update
    void Start()
    {
        eventSelect();
    }

    // Update is called once per frame
    void Update()
    {
        if(dateManager.dateNum % 7 == 6){
            eventTxt.text = "오늘은\n헌금의 날입니다.";
            content.text = "신에게 돈을 바치십시오.";
        }
    }

    void eventSelect(){
        int eventNum = Random.Range(0,100);

        eventTxt.text = "오늘도 평온합니다."; content.text = "";

        if(eventNum < 90){ // NO event
        } else { // 몰수 이벤트
            if(itemManager.beanNum >= 100){
                eventTxt.text = "경찰에서\n조사가 나왔습니다.";
                content.text = "50콩 몰수 되었습니다.";
                itemManager.beanNum -= 50;
            }
        }

    }
}
