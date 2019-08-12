using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcManager : MonoBehaviour
{
    public static bool[] npcList = new bool [6];
    // 0: 까마귀 / 1: 병아리 / 2: 비둘기 / 3: 펭귄 / 4: 앵무새 / 5: 어깨걸이
    public static int[] npcAbilty = {2,2,3,4,5,5};
    // 각 npc 별 신도수 증가 수치
    public static int[] npcGage = {0,0,0,0,0,0};
    // 호감도 수치

    // Start is called before the first frame update
    void Start()
    {
        //npcList[2] = true;
        //npcGage[2] = 100;
        for(int i = 0; i < 6; i++){
            if(npcGage[i] >= 99){
                npcList[i] = true;
                npcGage[i] = 100;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
