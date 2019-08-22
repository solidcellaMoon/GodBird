using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemText : MonoBehaviour
{
    public Text beanInfo;
    public Text diceInfo;

    // Start is called before the first frame update
    void Start()
    {
        beanInfo.text = ": " + itemManager.beanNum.ToString();
        diceInfo.text = ": " + itemManager.diceNum.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
