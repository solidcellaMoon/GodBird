using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static int beanScore;
    public static int diceScore;
    public Text currentScore, beanText, diceText;

    
    // Start is called before the first frame update
    void Start()
    {
        beanScore = 0;
        diceScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeManager.lifeNum != 0){
            // 게임 진행시 점수 표시
            currentScore.text = ": " + beanScore.ToString()
                            + "\n: " + diceScore.ToString();
        } else{
            // 게임 오버시 최종 점수 표시
            beanText.text =  ": " + beanScore.ToString();
            diceText.text =  ": " + diceScore.ToString();
        }
    }
}
