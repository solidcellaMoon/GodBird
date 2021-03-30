using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{
    public Text dateText, weekText;
    public GameObject dailyEvent;
    int countTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitTime());
    }

    // Update is called once per frame
    void Update()
    {   
        dateCalc();
        int weekNum = (dateManager.dateNum / 7) + 1;
        weekText.text = weekNum.ToString() + "주차";
        if(countTime == 2) { Destroy(gameObject);}
    }

    IEnumerator waitTime(){
        while(true) { 
            if(countTime == 1) {
                dateManager.dateNum++;
                dateManager.weekNum = dateManager.dateNum / 7;
                dailyEvent.SetActive(true);
            }
            countTime++;
            yield return new WaitForSeconds(0.5f);
            }
    }

    void dateCalc(){
        // 요일 표시
        switch(dateManager.dateNum % 7){
            case 0: dateText.text = "월요일"; break;
            case 1: dateText.text = "화요일"; break;
            case 2: dateText.text = "수요일"; break;
            case 3: dateText.text = "목요일"; break;
            case 4: dateText.text = "금요일"; break;
            case 5: dateText.text = "토요일"; break;
            case 6: dateText.text = "일요일"; break;
            default: break;
        }
    }
}
