using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject[] panel = new GameObject [2]; // 알림창 타입 리스트
    public GameObject touchXXX; // 터치 방지 영역 오브젝트
    public bool isFull = false; // 전체화면 모드 여부

    // Start()에서 해상도 등을 설정 - --
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "IntroScene"){
        Screen.SetResolution(450,800,false);
        Application.targetFrameRate = 60; }
    }

    // 인트로 장면으로 이동 ---
    public void ChangeToIntro(){
        SceneManager.LoadScene("IntroScene");
    }

    // 미니게임 장면으로 이동 ---
    public void ChangeToMiniGame(){
        if(dateManager.gameRetry > 0) SceneManager.LoadScene("MiniGame");
        else PanelOpen(0,true);
    }

    // 메인화면으로 이동 ---
    public void ChangeToMain(){
        if(SceneManager.GetActiveScene().name == "eventScene"
        && dateManager.dateNum % 7 == 6)  SceneManager.LoadScene("SundayScene");
        else SceneManager.LoadScene("MainScreen");
    }

    // 날짜 알림 씬으로 이동 ---
    public void ChangeToDateEvt(){
        // 현재 미니게임이라면, 점수를 표시한 뒤 씬 이동
        if(SceneManager.GetActiveScene().name == "MiniGame") ScoreLoad();
        SceneManager.LoadScene("eventScene");
    }

    // 엔딩 씬으로 이동 ---
    public void ChangeToEnding(){
        SceneManager.LoadScene("ending");
    }

    // 리스트 정보 패널 오픈 ---
    public void ChangeToList(){
        PanelOpen(2,true);
    }

    // 리스트 정보 패널 닫기 ---
    public void CloseList(){
        if(!panel[1].activeSelf) touchXXX.SetActive(false);
        panel[2].SetActive(false);
    }

    // Talk씬으로 이동하기 위한 패널 오픈 ---
    public void ChangeToTalk(){
        PanelOpen(1,true);
    }

    // 코스 선택 후 Talk씬으로 이동 ---
    public void StartTalk(){
        if (RandomCourse.Costsum > itemManager.beanNum)
        {
            PanelOpen(4, true);
        }
        else
        {
            SceneManager.LoadScene("TalkScene");
            itemManager.beanNum = itemManager.beanNum - RandomCourse.Costsum;
        }
    }

    // 경고창 표시 ---
    public void AlertWindow()
    {
        PanelOpen(3, true);
    }

    // 경고창 닫기 - 1번째 타입 ---
    public void CloseAlert()
    {
        if (!panel[1].activeSelf) touchXXX.SetActive(false);
        panel[3].SetActive(false);
    }

    // 경고창 닫기 - 2번째 타입 ---
    public void CloseAlert2()
    {
        if (!panel[1].activeSelf) touchXXX.SetActive(false);
        panel[4].SetActive(false);
    }

    // 미니 게임 점수를 메인 화면에 표시 ---
    public void ScoreLoad(){
        itemManager.beanNum += scoreManager.beanScore;
        itemManager.diceNum += scoreManager.diceScore;
    }

    // 알림창 열기 ---
    public void PanelOpen(int i, bool boolean){
        touchXXX.SetActive(boolean);
        panel[i].SetActive(boolean);
    }

    // 열려있는 알림창 닫기 ---
    public void RemovePanel(){
        touchXXX.SetActive(false);
        for(int i = 0; i < panel.Length; i++)
        if(panel[i].activeSelf) panel[i].SetActive(false);
    }

    //게임 종료 ---
    public void ExitGame(){
        Application.Quit();
    }

    //전체 화면 모드로 수정 ---
    public void ScreenSize(){
        if(isFull) isFull = false;
        else isFull = true;
        Screen.SetResolution(450,800,isFull);
    }

}
