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
    
    public Text scoreText, birdText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ": " + beanNum.ToString()
                        +"\n: " + diceNum.ToString();
        birdText.text = "신도: " + birdNum.ToString();
    }
}
