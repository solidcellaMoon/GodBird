using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject[] panel = new GameObject [2];
    public GameObject touchXXX;
    public void ChangeToMiniGame(){
        if(dateManager.gameRetry > 0) {
        //dateManager.gameRetry ++;
        SceneManager.LoadScene("MiniGame");
        dateManager.dateNum ++;
        //UItext.text = ": " + scoreManager.beanScore.ToString();
        } else{
            //panel = GameObject.Find("MinigamePanel");
            PanelOpen(0,true);
            // 이번주의 축복은 모두 끝났습니다.
        }
    }

    public void ChangeToMain(){
        // 미니게임 -> 메인화면 돌아오기 전용
        if(SceneManager.GetActiveScene().name == "MiniGame") ScoreLoad();
        SceneManager.LoadScene("MainScreen");
    }

    public void ChangeToList(){
        SceneManager.LoadScene("ListScene");
    }

    public void ChangeToTalk(){
        //panel = GameObject.Find("CourseSelect");
        PanelOpen(1,true);
    }

    public void StartTalk(){
        SceneManager.LoadScene("TalkScene");
    }

    public void ScoreLoad(){
        // 미니 게임 점수를 메인 화면에 표시
        itemManager.beanNum += scoreManager.beanScore;
        itemManager.diceNum += scoreManager.diceScore;
    }

    public void PanelOpen(int i, bool boolean){
        touchXXX.SetActive(boolean);
        panel[i].SetActive(boolean);
    }

    public void RemovePanel(){
        touchXXX.SetActive(false);
        for(int i = 0; i < panel.Length; i++)
        if(panel[i].activeSelf) panel[i].SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(450,800,false);
        //panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
