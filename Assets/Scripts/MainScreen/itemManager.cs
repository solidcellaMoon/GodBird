using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    public static int beanNum = 100, diceNum = 5;
    // 기본 자금 100콩, 주사위 5개
    public static int birdNum = 0;
    // 기본 신도수 0명
    public static int debtNum = 100;
    int debtRand = 50;

    public Text scoreText, birdText, debtInfo;

    // Start is called before the first frame update
    void Start()
    {
        if(beanNum < 0) beanNum = 0;
        if(diceNum < 0) diceNum = 0;
        if(birdNum < 0) birdNum = 0;

        if(dateManager.weekNum == 0) debtNum = 150;
        else if(dateManager.dateNum % 7 == 0) {
            debtRand = Random.Range(50,101);
            debtNum = debtRand + 100 * (dateManager.weekNum + 1);
         
            if (!successEvent.isClear) debtNum += debtManager.debt;
        }
        //debtNum = 100 + debtRand * (dateManager.weekNum + 1);

        debtInfo.text = "이번 주의\n유지보수 비용\n\n" + debtNum.ToString() + " 콩";

        

        // if(dateManager.weekNum == 0){
        //     debtInfo.text = "이번 주의\n유지보수 비용\n\n" + debtNum.ToString() + " 콩";
        // } else{
        //     if(successEvent.isClear)
        //     debtInfo.text = "이번 주의\n유지보수 비용\n\n" 
        //     + debtNum.ToString() + " 콩";
        //     else
        //     debtInfo.text = "이번 주의\n유지보수 비용\n\n"
        //     + (debtNum + debtManager.debt).ToString() + " 콩";
        // }


    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ": " + beanNum.ToString()
                        +"\n: " + diceNum.ToString();
        birdText.text = "신도: " + birdNum.ToString()+" 마리";
    }
}
