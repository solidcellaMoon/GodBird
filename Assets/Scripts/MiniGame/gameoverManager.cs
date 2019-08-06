using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameoverManager : MonoBehaviour
{   
    public GameObject Player, Generater, BasicUI, GameOverUI;
    PlayerMove playerScript;
    public Text retryText;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = Player.GetComponent<PlayerMove> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeManager.lifeNum == 0){
            mainCamera.backgroundColor = new Color32 (0,0,0,0);
            if(Player.activeSelf) dateManager.gameRetry--;
            Player.gameObject.SetActive(false);
            Generater.gameObject.SetActive(false);
            BasicUI.gameObject.SetActive(false);
            GameOverUI.gameObject.SetActive(true);

           if(dateManager.gameRetry > 0)
            retryText.text = "남은 도전 횟수\n" + 
            dateManager.gameRetry.ToString() + "번";
            else retryText.text = "이번 주의 축복이\n모두 끝났습니다.";
        }
    }
}
