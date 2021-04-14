using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mgManager : MonoBehaviour
{

    public GameObject TutoUI, BasicUI, StartUI;

    // Start is called before the first frame update
    void Start()
    {

        if(tutorialManager.mgTutorial){
            // 미니게임 튜토리얼 진행
            TutoUI.SetActive(true);
        }
        else{
            // 튜토리얼 없이 바로 진행
            StartUI.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
