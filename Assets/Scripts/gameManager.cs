using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//json 파일에 들어가는 게임 진행 정보 클래스
[System.Serializable]
public class saveData
{ 
    public int beanNum;
    public int diceNum;
    public int birdNum;
    public int dateNum;
    public int debtNum;
    public int chLevel;
    public int[] npcGage=new int [6];
    public int[] npcEnc = new int[6];
    public bool[] npcList = new bool[6];   
    public bool tutorial;
    public bool startpanelSee;
    public int weekNum;
    public int gameRetry;
     
   
}
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

        //**추가된 변수와 초기값들 
        //npc 영입여부(영입 성공 팝업 중복 방지)
        npcManager.npcList = new bool[] { false, false, false, false, false, false };
        //튜토리얼 보여줄지 여부-스킵했거나 두번째 플레이면 띄우지 않는다.
        tutorialManager.tutorial = true;
        //프롤로그 보여줄지 여부-스킵했거나 시청했으면 인토르씬에서 안내 패널을 띄우지 않는다.
        IntroUI.startpanelSee = true;      
        dateManager.weekNum = 0; // week: n주차
        dateManager.gameRetry = 3; //미니게임 가능 횟수 
       
    }
     
    //미니게임 난이도 관리 변수 ---
    public static int gameRetry = 3; // 일주일간 미니게임 가능 횟수
    public static int gameLifeNum = 4; // 미니게임 초기 하트 개수 (최대 6개까지 가능)
    public static int gameLimit = 399; // 한 판에 콩 400개 이상 못얻음

    //public static gameManager instance;

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


    string filePath;//저장되는 위치

    // Start is called before the first frame update
    void Start()
    {       
        filePath  = Application.persistentDataPath + "/clearInfo.json";
        //저장정보 불러옴       
        Load();
      //  PrintData();
    }

    // Update is called once per frame
    void Update()
    {
        //PrintData();
    }

     //**  세이브 함수들   **// 

     //저장 파일 만드는 함수 
    public static void makeD()
    {
        saveData data = new saveData();

        //저장값들을 전부 초기값으로 설정 
        data.beanNum = 250; // 보유 콩 개수
        data.diceNum = 10; // 보유 주사위 개수
        data.birdNum = 1; // 보유 신도 수
        data.dateNum = -1; // 게임상의 날짜
        data.debtNum = 150; // 현재 갚아야 할 빚 액수
        data.chLevel = 0; // 현재 교회 레벨
        for (int i = 0; i < 6; i++)
        {
            data.npcGage[i] = 0;  // npc별 현재 호감도 수치
            data.npcEnc[i] = 0;   // npc별 현재 만남 횟수
            data.npcList[i] = false;
        }
        data.tutorial = true;
        data.startpanelSee = true;

        data.weekNum = 0; // week: n주차
        data.gameRetry = 3; //미니게임 가능 횟수 
       
        File.WriteAllText(Application.persistentDataPath + "/clearInfo.json", JsonUtility.ToJson(data));
        //Debug.Log("저장 파일 생성!");
    }
    //로드(불러오기) 함수
    public void Load()
    {

        //파일이 없으면 해당위치에 만든다.(첫 실행 시)
        if (!File.Exists(filePath)) { makeD();  }

        //json값을 읽어와 data 인스턴스에 넣는다. 
        string str = File.ReadAllText(Application.persistentDataPath + "/clearInfo.json");
        saveData data = JsonUtility.FromJson<saveData>(str);

        //읽어온 정보를 사용되는 스크립트의 변수에 넣어서 업데이트         
        itemManager.beanNum = data.beanNum;  
        itemManager.diceNum = data.diceNum; 
        itemManager.birdNum = data.birdNum;  
        dateManager.dateNum = data.dateNum;  
        itemManager.debtNum = data.debtNum;  
        churchManager.chLevel = data.chLevel;  
        for (int i = 0; i < 6; i++)
        {
            npcManager.npcGage[i] =data.npcGage[i] ;  
            npcManager.npcEnc[i] = data.npcEnc[i];
            npcManager.npcList[i] = data.npcList[i];
        }
        
        tutorialManager.tutorial = data.tutorial;    
        IntroUI.startpanelSee = data.startpanelSee;

        dateManager.weekNum=data.weekNum;  
        dateManager.gameRetry = data.gameRetry;  
      

    }
    //세이브 함수 
    public static void Save()
    {
        saveData data = new saveData();

        //각 스크립트에서 값을 data의 변수들에 넣고 파일에 쓴다.       
        data.beanNum = itemManager.beanNum;  
        data.diceNum = itemManager.diceNum;  
        data.birdNum = itemManager.birdNum;  
        data.dateNum = dateManager.dateNum;  
        data.debtNum = itemManager.debtNum;  
        data.chLevel = churchManager.chLevel;  
        for (int i = 0; i < 6; i++)
        {
            data.npcGage[i] = npcManager.npcGage[i];   
            data.npcEnc[i] = npcManager.npcEnc[i];
            data.npcList[i] = npcManager.npcList[i];
        }
        data.tutorial = tutorialManager.tutorial;
        data.startpanelSee= data.startpanelSee;

        data.weekNum= dateManager.weekNum;  
        data.gameRetry = dateManager.gameRetry;  
        
        File.WriteAllText(Application.persistentDataPath + "/clearInfo.json", JsonUtility.ToJson(data));
        Debug.Log("세이브!");
    }
   
    public static void reset()
    {

        //리셋시 GameManager 중복으로 생기는 것 방지
        GameObject gamemanager = GameObject.Find("Game Manager");
        if (gamemanager != null) { Destroy(gamemanager); }

        //새로운 저장 파일로 덮어써서 초기화한다.
        makeD();
       
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
