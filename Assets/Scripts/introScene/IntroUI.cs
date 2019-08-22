using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{

    public GameObject Panel;

    public void StartClick(){
        Panel.SetActive(true);
    }

    public void skipOK(){
        tutorialManager.tutorial = false;
        SceneManager.LoadScene("eventScene");
        // 프롤로그 없이 바로 시작
    }

    public void skipNo(){
        // 프롤로그 표시
        tutorialManager.tutorial = true;
        SceneManager.LoadScene("Prologue");
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
