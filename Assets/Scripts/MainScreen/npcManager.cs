using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcManager : MonoBehaviour
{
    public static bool[] npcList = new bool [6];
    // 0: 까마귀 / 1: 병아리 / 2: 비둘기 / 3: 펭귄 / 4: 앵무새 / 5: 어깨걸이
    public static int[] npcAbilty = {2,2,3,4,5,5};
    // 각 npc 별 신도수 증가 수치
    public static int[] npcGage = {0,0,0,0,0,0};
    // 호감도 수치
    public static int[] npcEnc = {0,0,0,0,0,0};
    // npc별 만남 횟수

    public GameObject npcPanel, touchXXX;
    public Text npcText;
    public GameObject[] npc = new GameObject [6];
    string name;

    // Start is called before the first frame update
    void Start()
    {
        name = "";
        // 중복 알림은 아직 못만듬...
        
        for(int i = 0; i < 6; i++){
            if(npcGage[i] >= 99){
                if(!npcList[i]){
                    touchXXX.SetActive(true);
                    npcPanel.SetActive(true);
                    npcText.text = npcName(i);
                }
                npcList[i] = true;
                npcGage[i] = 100;
            }
            if(npcList[i]) npc[i].SetActive(true);
        }
    }

    string npcName(int i){
        switch(i){
            case 0: name = "까마귀 가 "; break;
            case 1: name = "병아리 가 "; break;
            case 2: name = "비둘기 가 "; break;
            case 3: name = "펭귄 이 "; break;
            case 4: name = "앵무새 가 "; break;
            case 5: name = "어깨걸이 극락조 가 "; break;
        }
        name += "당신을\n전적으로 믿게 되었습니다.";
        return name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
