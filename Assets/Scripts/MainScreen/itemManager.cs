using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    public static int beanNum = 0, diceNum = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ": " + beanNum.ToString()
                        +"\n: " + diceNum.ToString();
    }
}
