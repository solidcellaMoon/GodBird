using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemText : MonoBehaviour
{
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ": " + itemManager.beanNum.ToString()
                        +"\n: " + itemManager.diceNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
