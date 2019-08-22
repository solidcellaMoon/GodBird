using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dateManager : MonoBehaviour
{
    public static int dateNum = -1;
    public static int weekNum = 0;
    // date: 날짜 week: 몇주차인지
    // 일주일이 지나면 날짜는 다시 0 부터 초기화

    public Text uiText;
    public static string date; // 요일 글자

    public static int gameRetry = 3; // 일주일간 미니게임 가능 횟수


    // Start is called before the first frame update
    void Start()
    {
        if(dateNum % 7 == 0) gameRetry = 3; // 월요일이면 미니게임 횟수 리셋
        dateCalc();
        //weekNum = dateNum / 7;
        uiText.text = weekNum.ToString() + "\n" + date;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    void dateCalc(){
        // 요일 표시
        switch(dateNum % 7){
            case 0: date = "월"; break;
            case 1: date = "화"; break;
            case 2: date = "수"; break;
            case 3: date = "목"; break;
            case 4: date = "금"; break;
            case 5: date = "토"; break;
            case 6: date = "일"; break;
            default: break;
        }
    }
}
