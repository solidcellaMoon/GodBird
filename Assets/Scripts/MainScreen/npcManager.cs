using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcManager : MonoBehaviour
{
    public static bool[] npcList = new bool [6]; // 각 npc의 호감도 MAX 여부를 저장
    // 0: 까마귀 / 1: 병아리 / 2: 비둘기 / 3: 펭귄 / 4: 앵무새 / 5: 어깨걸이
    
    public static int[] npcAbilty = {2,2,3,4,5,5}; // 각 npc 별 신도수 증가 수치
    public static int[] npcGage = {0,0,0,0,0,0}; // 호감도 수치
    public static int[] npcEnc = {0,0,0,0,0,0}; // npc별 만남 횟수

    public GameObject npcPanel, touchXXX; // 알링창, 터치 금지 파트
    public Text npcText; // 알림 텍스트
    public GameObject[] npc = new GameObject [6]; // npc 오브젝트 리스트
    string birdName; // npc 이름

    void Start()
    {
        birdName = ""; // 중복 알림은 미구현
        
        for(int i = 0; i < 6; i++){
            if(npcGage[i] >= 99){ // 해당 npc의 호감도가 MAX라면
                if(!npcList[i]){ //npcList가 false일 때
                    // 알림창을 띄우고 문장을 출력
                    touchXXX.SetActive(true);
                    npcPanel.SetActive(true);
                    npcText.text = npcName(i);
                }
                npcList[i] = true;
                npcGage[i] = 100; // List의 항목을 true로, Gage는 100으로 고정
            }

            // npcList가 true일 때
            if(npcList[i]) npc[i].SetActive(true); // 해당 npc 오브젝트를 표시
        }
    }

    string npcName(int i){ // npc 영입 성공 문구 출력
        switch(i){
            case 0: birdName = "까마귀 가 "; break;
            case 1: birdName = "병아리 가 "; break;
            case 2: birdName = "비둘기 가 "; break;
            case 3: birdName = "펭귄 이 "; break;
            case 4: birdName = "앵무새 가 "; break;
            case 5: birdName = "어깨걸이 극락조 가 "; break;
        }
        birdName += "당신을\n전적으로 믿게 되었습니다.";
        return birdName;
    }

}
