using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreLoad : MonoBehaviour
{
    public GameObject scsPanel, lvUpPanel;
    public Text textArea;
    int score;

    void Update()
    {
        if(gameObject.name == "debtText") score = debtManager.debt;
        else if(gameObject.name == "prptyText") score = itemManager.beanNum;

        if(!scsPanel.activeSelf && !lvUpPanel.activeSelf)
        StartCoroutine(loadScore(score, textArea));

    }
    IEnumerator loadScore(int num, Text textArea){
        int i = num - 50;
        if(i < 0) i = 0;
        while(i <= num){
            textArea.text = ": "+ i.ToString(); i++;
            yield return new WaitForSeconds(0f);
        }
    }
}
