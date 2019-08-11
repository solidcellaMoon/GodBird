using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelScript : MonoBehaviour
{
    public GameObject scsPanel, lvUpPanel;

    public void scsPanelClose(){

        if(successEvent.isClear) //빚을 갚은 상태일 때
        switch (dateManager.weekNum + 1) {
            case 1: case 3: case 6: case 11: //레벨업하는 주차
            scsPanel.SetActive(false); // 성공여부 팝업을 닫고
            lvUpPanel.SetActive(true); // 레벨업 팝업을 오픈
            break;
            default: SceneManager.LoadScene("eventScene"); break;
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
