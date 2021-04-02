using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    //**중요** 게임 세이브에 필요한 변수와 초기값들 모음
    void SaveData(){
        itemManager.beanNum = 250; // 보유 콩 개수
        itemManager.diceNum = 10; // 보유 주사위 개수
        itemManager.birdNum = 1; // 보유 신도 수
        dateManager.dateNum = -1; // 게임상의 날짜
        itemManager.debtNum = 150; // 현재 갚아야 할 빚 액수
        churchManager.chLevel = 0; // 현재 교회 레벨
        npcManager.npcGage = new int[] {0,0,0,0,0,0}; // npc별 현재 호감도 수치
        npcManager.npcEnc = new int[] {0,0,0,0,0,0}; // npc별 현재 만남 횟수
    }


    //미니게임 난이도 관리 변수 ---
    public static int gameRetry = 3; // 일주일간 미니게임 가능 횟수
    public static int gameLifeNum = 4; // 미니게임 초기 하트 개수 (최대 6개까지 가능)
    public static int gameLimit = 399; // 한 판에 콩 400개 이상 못얻음

    void Awake(){
        DontDestroyOnLoad(gameObject);
        DayValues(); // 게임 날짜 관리
        MiniValues(); // 미니게임 난이도 관리
        ItemValues(); // 아이템 개수 관리
        DebtValues(); // 빚 난이도 관리
        BldgValues(); // 빌딩 레벨 관리
        NpcValues(); // npc 호감도, 능력 관리
    }

    void DayValues(){
        dateManager.dateNum = -1; // date: 날짜
        dateManager.weekNum = 0; // week: n주차
        dateManager.gameRetry = gameRetry; // 일주일간 미니게임 가능 횟수
    }

    void ItemValues(){
        itemManager.beanNum = 250; // 콩 수
        itemManager.diceNum = 10; // 주사위 수
        itemManager.birdNum = 1; // 신도 수
    }

    void DebtValues(){
        itemManager.debtNum = 150; // 초기 빚
        debtManager.debt = 0; // 누적 빚
    }

    void BldgValues(){ // 교회 레벨 관리
        churchManager.chLevel = 0; //기본 레벨은 0
        churchManager.chAbility = new int[] {0,1,5,10,100}; // 레벨에 따른 능력
        churchManager.chDay = new int[] {1,2,3,4,5}; //레벨업 조건 성공 횟수(ex: 1번 빚갚으면 다음 건물로 렙업)
    }

    void NpcValues(){
        // 0: 까마귀 / 1: 병아리 / 2: 비둘기 / 3: 펭귄 / 4: 앵무새 / 5: 어깨걸이
        npcManager.npcList = new bool[] {false, false, false, false, false, false};
        npcManager.npcAbilty = new int[] {2,2,3,4,5,5}; // 각 npc 별 신도수 증가 수치
        npcManager.npcGage = new int[] {0,0,0,0,0,0}; // 호감도 수치
        npcManager.npcEnc = new int[] {0,0,0,0,0,0}; // npc별 만남 횟수

    }

    void MiniValues(){ // 미니게임 난이도 관리
        lifeManager.lifeNum = gameLifeNum; // 초기 하트 개수 (최대 6개까지 가능)
        lifeManager.limit = gameLimit; // 한 판에 콩 400개 이상 못얻음
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PrintData();
    }
    void PrintData(){ // 데이터 확인용 (임시)
        Debug.Log("debt:"+itemManager.debtNum);
        Debug.Log("Bean:"+itemManager.beanNum);
        Debug.Log("Dice:"+itemManager.diceNum);
        Debug.Log("BirdNum:"+itemManager.birdNum);
        Debug.Log("date:"+dateManager.dateNum);
        Debug.Log("week:"+dateManager.weekNum);
        Debug.Log("Ch Level:"+churchManager.chLevel);
        Debug.Log("npcGage:"+npcManager.npcGage);
        foreach(int i in npcManager.npcGage){
            Debug.Log(i);
        }
        Debug.Log("npcEnc:"+npcManager.npcEnc);
        foreach(int i in npcManager.npcEnc){
            Debug.Log(i);
        }
    }

}
