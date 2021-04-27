using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialManager : MonoBehaviour
{

    public static bool tutorial;

    public static bool mgTutorial = true; // 미니게임 튜토리얼 출력 여부

    public GameObject panel, touchX, player, mgPanel;
    public GameObject[] page = new GameObject [4];

    public GameObject rejectPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(tutorial){
            player.SetActive(false);
            touchX.SetActive(true);
            panel.SetActive(true);
        }
    }

    public void p1Click(){
        page[0].SetActive(false);
        page[1].SetActive(true);
    }

    public void p2Click(){
        page[1].SetActive(false);
        page[2].SetActive(true);
    }
    public void p3Click(){
        page[2].SetActive(false);
        page[3].SetActive(true);
    }

    public void p4Click(){
        touchX.SetActive(false);
        panel.SetActive(false);
        player.SetActive(true);
        tutorial = false;
    }

    public void miniGamePanel(){
        if (mgTutorial)
        {
            touchX.SetActive(true);
            mgPanel.SetActive(true);
        }
        else if (dateManager.gameRetry > 0) SceneManager.LoadScene("MiniGame");
        else rejectPanel.SetActive(true);
    }

    public void skipOK(){ // 미니게임 튜토리얼 스킵
        mgTutorial = false;
        Debug.Log("미니게임 튜토리얼 스킵");
        //SceneManager.LoadScene("MiniGame");
    }

    public void skipNo(){ // 미니게임 튜토리얼 진행
        mgTutorial = true;
        Debug.Log("미니게임 튜토리얼 진행");
        //SceneManager.LoadScene("MiniGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
