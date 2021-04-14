using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public GameObject tutorialUI, startUI, touchX, musicPlayer;

    // Start is called before the first frame update
    void Start()

    {

        if(tutorialManager.mgTutorial){
            touchX.SetActive(true);
            tutorialUI.SetActive(true);
        }
        else{
            startUI.SetActive(true);
            musicPlayer.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {  
         
    }

}
