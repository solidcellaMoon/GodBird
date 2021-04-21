using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class DialogManager : MonoBehaviour
{
    public static bool talkStart = true;
    string birdName, placeName;
    string [] lastBird = new string [4];
    int meetingNum;
    string[] birdArr = new string[]
    {"crow","chick","pigeon","penguin","parrot","paradise"};
    string jsonFile = "Data.json";
    public GameObject questionText,motion;
    public GameObject example1Text, example2Text, example3Text;
    public GameObject touchXXX, touchX, touchXX;
    // 전자, 선택한 후 잠시 터치 불가
    // 후자 2개, 텍스트 출력시 터치 불가

    // json 파일 범위 지정에 필요
    Dictionary<string, string>[] problems = new Dictionary<string, string>[46];

    int problemNumber, problemCount = 0, totalCorrect = 0;
    string question = "";
    string example1 = ""; string example2 = ""; string example3 = "";
    string answer = ""; string soso = "";
    public GameObject totalCorrectText, correctIncorrectText;
    public GameObject timeBarImage, placeText;
    TimeAttackController timeBar;

    int index = 0, birdIndex = 0, lastRand;
    public static bool check = false; // 대답시 트루. 트루면 타임이 멈춤.
    public static bool questEnd = false;

    public AudioSource talkBgm, clockBgm, goodBgm, sosoBgm, badBgm;

    // 안드로이드 빌드시, GameObject에 대화문 선언 script 넣어서 가져오기
    public GameObject DialogData;


    void infoInit(){
        talkStart = true;
        // 장소 이름
        placeName = MapManager.map[index].name; WhatBird();
        // 새 종류 지정
        //birdSelect();
        birdName = birdArr[MapManager.birdType];
        lastBird[birdIndex] = birdName; birdIndex ++;

        meetingNum = npcManager.npcEnc[MapManager.birdType];
    }

    void OnEnable(){

        supervisor.clear = false;

        touchX.SetActive(true); touchXX.SetActive(true); touchXXX.SetActive(false);
        infoInit();

        placeText.GetComponent<Text>().text = placeName;

        /*
        string jsonFilePath = Application.dataPath + "/Resources/BirdDialogue/" + birdName + jsonFile;

        if (File.Exists(jsonFilePath))
        {
            string str = File.ReadAllText(jsonFilePath);
            JsonData jsonData = JsonUtility.FromJson<JsonData>(str);
            int i = 0;
            foreach (Problem problem in jsonData.problems)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();
                temp.Add("question", problem.question);
                temp.Add("example1", problem.example1);
                temp.Add("example2", problem.example2);
                temp.Add("example3", problem.example3);
                temp.Add("answer", problem.answer);
                temp.Add("soso", problem.soso);
                temp.Add("meeting", problem.meeting);
                problems[i] = temp;
                i++;
            }
        }
        else Debug.Log("json file error");
        */

        // 안드로이드 빌드용 데이터 Script에서 가져오기
        switch (birdName)
        {
            case "crow":
                problems = DialogData.GetComponent<crow>().crowDic;
                break;
            case "chick":
                problems = DialogData.GetComponent<chick>().chickDic;
                break;
            case "pigeon":
                problems = DialogData.GetComponent<pigeon>().pigeonDic;
                break;
            case "penguin":
                problems = DialogData.GetComponent<penguin>().penguinDic;
                break;
            case "parrot":
                problems = DialogData.GetComponent<parrot>().parrotDic;
                break;
            case "paradise":
                problems = DialogData.GetComponent<paradise>().paradiseDic;
                break;
            default:
                problems = DialogData.GetComponent<chick>().chickDic;
                break;
        }

        SetProblemNum();
        StartCoroutine(printTxt("meeting"));
        totalCorrectText.GetComponent<Text>().text = "호감도: 0";
        correctIncorrectText.GetComponent<Text>().text = "Correct/Incorrect";
    }

    void SetProblemNum()
    {
        if (meetingNum == 0) problemNumber = 1;
        else{
            // json 파일 범위 지정에 필요
            int ranNum = Random.Range(1, 15);
            foreach(string str in lastBird){
                if(birdName == str){
                    while(ranNum == lastRand) ranNum = Random.Range(1, 15);
                }
            }
            problemNumber = 3 * ranNum + 1;
            lastRand = ranNum;
        }
    }

    void ShowProblem()
    {
        clockBgm.Play();
        check = false;
        questEnd = true;
        touchX.SetActive(false); touchXX.SetActive(false);

        example1 = "> " + problems[problemNumber - 1]["example1"];
        example2 = "> " + problems[problemNumber - 1]["example2"];
        example3 = "> " + problems[problemNumber - 1]["example3"];
        answer = "> " + problems[problemNumber - 1]["answer"];
        soso = "> " + problems[problemNumber - 1]["soso"];

        timeBar = timeBarImage.GetComponent<TimeAttackController>();
        if (timeBar) timeBar.timeLeft = 5f;
        else Debug.Log("other script object error");
        
        example1Text.GetComponent<Text>().text = example1;
        example2Text.GetComponent<Text>().text = example2;
        example3Text.GetComponent<Text>().text = example3;

        problemCount++;
    }

    IEnumerator printTxt(string str){
        int i = 0;
        question = problems[problemNumber - 1][str];
        char[] arr = question.ToCharArray();
        if(question != null){
            for(i = 0; i < arr.Length; i++){
            talkBgm.pitch = 1;
            if(str == "question") talkBgm.pitch = 3;
            questionText.GetComponent<Text>().text += arr[i]; talkBgm.Play();            
            yield return new WaitForSeconds(0.06f);
            }
        }
        if(str == "meeting") {
            yield return new WaitForSeconds(1f);
            questionText.GetComponent<Text>().text = "";
            StartCoroutine(printTxt("question"));
        } else Invoke("ShowProblem", 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(check) touchXXX.SetActive(true);
        else touchXXX.SetActive(false);

        if(TimeAttackController.failed && questEnd) {
            TimeAttackController.failed = false;
            motionSelect("오답");
            badBgm.Play();
            clockBgm.Pause();
            Invoke("NextOrOverCheck",2);
        }

    }

    void SelectExample(string example)
    {
        Debug.Log(example);

        if (answer.Equals(example))
        {
            totalCorrect += 11;
            totalCorrectText.GetComponent<Text>().text = "호감도: " + totalCorrect.ToString();
            correctIncorrectText.GetComponent<Text>().text = "호감도 11 up";
            motionSelect("정답");
            goodBgm.Play();

        }
        else if (soso.Equals(example))
        {
            totalCorrect += 5;
            totalCorrectText.GetComponent<Text>().text = "호감도: " + totalCorrect.ToString();
            correctIncorrectText.GetComponent<Text>().text = "호감도 5 up";
            motionSelect("보통");
            sosoBgm.Play();
        }
        else
        {
            totalCorrectText.GetComponent<Text>().text = "호감도: " + totalCorrect.ToString();
            correctIncorrectText.GetComponent<Text>().text = "호감도 0 up";
            motionSelect("오답");
            badBgm.Play();
        }
        clockBgm.Pause();
        Invoke("NextOrOverCheck",2f);
    }

    public void NextOrOverCheck()
    {
            check = false;
            questEnd = false;
            questionText.GetComponent<Text>().text = "";

        if (problemCount < 3)
        {
            problemNumber++;
            touchX.SetActive(true); touchXX.SetActive(true);
            example1Text.GetComponent<Text>().text = "";
            example2Text.GetComponent<Text>().text = "";
            example3Text.GetComponent<Text>().text = "";
            StartCoroutine(printTxt("question"));
        }
        else
        {
            problemCount = 0;
            npcManager.npcGage[MapManager.birdType] += totalCorrect;
            npcManager.npcEnc[MapManager.birdType]++;
            totalCorrect = 0;
            index ++;
            talkStart = false;
        }
    }

    public void Example1ButtonClicked()
    {
        Debug.Log("Example1ButtonClicked");
        SelectExample(example1);
    }

    public void Example2ButtonClicked()
    {
        Debug.Log("Example2ButtonClicked");
        SelectExample(example2);
    }

    public void Example3ButtonClicked()
    {
        Debug.Log("Example3ButtonClicked");
        SelectExample(example3);
    }

    public void motionSelect(string type){
        check = true;
        motion.SetActive(true);
        motionController.name = type;
    }

        void WhatBird(){
        switch(npcManager.npcGage[MapManager.birdType]){
            case 0: supervisor.str = "까마귀는"; break;
            case 1: supervisor.str = "병아리는"; break;
            case 2: supervisor.str = "비둘기 노부부는"; break;
            case 3: supervisor.str = "펭귄"; break;
            case 4: supervisor.str = "앵무새는"; break;
            case 5: supervisor.str = "어깨걸이 극락조는"; break;
        }
    }

}


