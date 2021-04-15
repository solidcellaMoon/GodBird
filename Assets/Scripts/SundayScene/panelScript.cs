using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelScript : MonoBehaviour
{
    public GameObject scsPanel, lvUpPanel, edPanel;
    int[] chDay;

    void Awake(){
        chDay = churchManager.chDay;

        dateManager.decideDebt = false;
        gameManager.Save();
    }

    public void scsPanelClose(){

        if(successEvent.isClear) { //빚을 갚은 상태일 때

            foreach(int week in churchManager.chDay){
                if (successEvent.ClearNum == chDay[chDay.Length - 1]){
                    scsPanel.SetActive(false); // 성공여부 팝업을 닫고
                    edPanel.SetActive(true); // 엔딩 팝업을 오픈
                    break;
                }
                if(successEvent.ClearNum == week){ //레벨업하는 주차
                    scsPanel.SetActive(false); // 성공여부 팝업을 닫고
                    lvUpPanel.SetActive(true); // 레벨업 팝업을 오픈
                    break;
                }
            }

            // switch (successEvent.ClearNum) {
            //     case 1: case 2: case 3: case 4: //레벨업하는 주차
            //     scsPanel.SetActive(false); // 성공여부 팝업을 닫고
            //     lvUpPanel.SetActive(true); // 레벨업 팝업을 오픈
            //     break;
            //     default: SceneManager.LoadScene("eventScene"); break;
            // } 

            // for(int i=0; i<chDay.Length; i++){
            //     if(successEvent.ClearNum == chDay[i]){
            //         scsPanel.SetActive(false); // 성공여부 팝업을 닫고
            //         lvUpPanel.SetActive(true); // 레벨업 팝업을 오픈
            //         break;
            //     }
            // }
        }
        else SceneManager.LoadScene("eventScene");


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
