using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class saveBtn : MonoBehaviour
{
    public GameObject btn;
    public GameObject savebtn;
  
    // Start is called before the first frame update
    void Start()
    {
        //세이브 함수 드래그해서 설정시 missing되는 문제때문에 스크립트로 onclick 설정
        //메인씬에서 사용중이면 리셋 함수를 붙인다. (환경설정의 초기화버튼)
        if (SceneManager.GetActiveScene().name == "MainScreen")
        {
            btn.GetComponent<Button>().onClick.AddListener(localReset);
            //추가1. npc 영입 팝업의 확인 버튼을 눌렀다면 세이브해준다. (팝업 중복 방지)
            savebtn.GetComponent<Button>().onClick.AddListener(localSave);
          
        }
        //이벤트씬에서 사용중이면 세이브 함수를 붙인다. (하루가 지날때마다 자동 세이브)
        else if (SceneManager.GetActiveScene().name == "eventScene")
        {
            btn.GetComponent<Button>().onClick.AddListener(localSave);
        }
    }
    void localSave()
    {
        gameManager.Save();
    }
    void localReset()
    {
        gameManager.reset();   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
