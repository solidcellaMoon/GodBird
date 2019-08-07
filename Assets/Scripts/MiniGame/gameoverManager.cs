using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameoverManager : MonoBehaviour
{   
    public GameObject GameOverUI;
    public GameObject[] obj = new GameObject [3];
    PlayerMove playerScript;
    public Text retryText;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = obj[0].GetComponent<PlayerMove> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeManager.lifeNum == 0){
            mainCamera.backgroundColor = new Color32 (0,0,0,0);

            if(obj[0].activeSelf) {
                dateManager.gameRetry--;
                for(int i = 0; i < obj.Length; i++)
                    if(obj[i].activeSelf) obj[i].SetActive(false);
                GameOverUI.gameObject.SetActive(true); 
                }
           

           if(dateManager.gameRetry > 0)
            retryText.text = "남은 도전 횟수\n" + 
            dateManager.gameRetry.ToString() + "번";
            else retryText.text = "이번 주의 축복이\n모두 끝났습니다.";
        }
    }
}
