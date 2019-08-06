using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public GameObject Player, Generater, BasicUI, GameOverUI;
    PlayerMove playerScript;
    public Text currentScore, beanScore, diceScore, retryText;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(450,800,false);
        playerScript = Player.GetComponent<PlayerMove> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeManager.lifeNum == 0){
            if(Player.activeSelf) playerScript.retryNum--;
            Player.gameObject.SetActive(false);
            Generater.gameObject.SetActive(false);
            BasicUI.gameObject.SetActive(false);
            GameOverUI.gameObject.SetActive(true);

            beanScore.text =  ": " + scoreManager.beanScore.ToString();
            diceScore.text =  ": " + scoreManager.diceScore.ToString();
           if(playerScript.retryNum > 0)
            retryText.text = "남은 도전 횟수\n" + 
            playerScript.retryNum.ToString() + "번";
            else retryText.text = "이번 주의 축복이\n모두 끝났습니다.";
        } else{
            currentScore.text = ": " + scoreManager.beanScore.ToString()
            + "\n: " + scoreManager.diceScore.ToString();
        }
    }

     public void RetryPressed(){
         /*
         if(playerScript.retryNum > 0){
        Player.gameObject.SetActive(true);
        Generater.gameObject.SetActive(true);
        BasicUI.gameObject.SetActive(true);
        lifeManager.lifeNum = 3;
        scoreManager.beanScore = 0;
        scoreManager.diceScore = 0;
        GameOverUI.gameObject.SetActive(false);}
          */
    }
}
