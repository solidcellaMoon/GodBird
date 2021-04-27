using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{

    public GameObject Panel;
    public static bool startpanelSee = true;
    public void StartClick(){


        Debug.Log(gameManager.gameClear);
        
        // if(gameManager.gameClear){ // 엔딩 봤으면 일요일 -> 월요일
        //     SceneManager.LoadScene("eventScene");
        // }

        if(startpanelSee)  //첫플레이면 안내 패널을 띄우고
            Panel.SetActive(true);
        //저장 파일이 있는 상태면 바로 메인으로
        else SceneManager.LoadScene("MainScreen");
    }

    public void skipOK(){
        startpanelSee = false;
        tutorialManager.tutorial = false;
        SceneManager.LoadScene("eventScene");
        // 프롤로그 없이 바로 시작
        

    }

    public void skipNo(){
        // 프롤로그 표시
        tutorialManager.tutorial = true;
        startpanelSee = false;
        SceneManager.LoadScene("Prologue");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("시작");
        if(gameManager.gameClear) gameManager.gameRetry = 7; // 1회차 이상은 미니게임 무제한으로 가능 (7일에 7번까지)
        else gameManager.gameRetry = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
