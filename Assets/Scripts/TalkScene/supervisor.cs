using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class supervisor : MonoBehaviour
{
    public GameObject defCanvas, npcPanel, touchXXX;
    public Text txtArea;
    int npcGage;
    public static string str;
    public static bool clear = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(waitTime());
    }

    // Update is called once per frame
    void Update()
    {
        //npcGage = npcManager.npcGage[MapManager.birdType];
        if(defCanvas.activeSelf && npcGage >= 99 && npcGage != 100){
            touchXXX.SetActive(true);
            npcPanel.SetActive(true);
            txtArea.text = str + "\n전적으로 당신을 믿게 되었습니다";
            //Time.timeScale = 0.0f; // 게임 일시 정지
        }
    }

    public void BtnClick(){
        //Time.timeScale = 1.0f; // 게임 재개
        touchXXX.SetActive(false);
        npcPanel.SetActive(false);
        clear = true;
    }

}
