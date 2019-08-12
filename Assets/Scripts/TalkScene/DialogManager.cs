using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class DialogManager : MonoBehaviour
{
    public static bool talkStart = true;
    string birdName = "crow";
    int meetingNum = 1;
    string placeName = "잔디공원";

    string[] birdArr = new string[]
    {"crow","chick","pigeon","penguin","parrot","paradise"};


    string jsonFile = "Data.json";
 
    public GameObject questionText;
    public GameObject example1Text;
    public GameObject example2Text;
    public GameObject example3Text;

    Dictionary<string, string>[] problems = new Dictionary<string, string>[15];

    int problemNumber;
    int problemCount = 0;
    string question = "";
    string example1 = "";
    string example2 = "";
    string example3 = "";
    string answer = "";
    string soso = "";
    string meeting = "";

    int totalCorrect = 0;
    public GameObject totalCorrectText;
    public GameObject correctIncorrectText;

    public GameObject gameOverPanel;

    public GameObject timeBarImage;

    public GameObject placeText;

    int index = 0;
    int birdType = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void infoInit(){
        // 장소 이름
        placeName = RandomCourse.placeNow[index].name;
        // 새 종류 지정
        birdSelect();

    }

    void birdSelect(){
        switch(MapChecker.mapOutput[index]){
            case 0: // 잔디공원
            birdType = Random.Range(0,2); birdName = birdArr[birdType]; break;
            case 1: // 바름배움촌
            birdType = Random.Range(1,3); birdName = birdArr[birdType]; break;
            case 2: // 회색도심
            birdType = Random.Range(0,2); if(birdType == 1) birdType = 2; 
            birdName = birdArr[birdType]; break;
            case 3: // 야자바다
            birdType = Random.Range(3,5); birdName = birdArr[birdType]; break;
            case 4: // 정글숲
            birdType = Random.Range(4,6); birdName = birdArr[birdType]; break;
            case 5: // 북극설원
            birdType = Random.Range(3,5); if(birdType == 3) birdType = 5; 
            birdName = birdArr[birdType]; break;
        }
    }

    void OnEnable(){

        talkStart = true;
        infoInit();
        placeText.GetComponent<Text>().text = placeName;

        string jsonFilePath = Application.dataPath + "/BirdDialogue/" + birdName + jsonFile;

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
        else
        {
            Debug.Log("json file error");
        }

        SetProblemNum();
        ShowProblem();
        totalCorrectText.GetComponent<Text>().text = "호감도: 0";
        correctIncorrectText.GetComponent<Text>().text = "Correct/Incorrect";
    }

    void SetProblemNum()
    {
        if (meetingNum == 0)
        {
            problemNumber = 1;
        }
        else
        {
            int ranNum = Random.Range(1, 5);
            problemNumber = 3 * ranNum + 1;
        }
    }

    void ShowProblem()
    {
        question = problems[problemNumber - 1]["question"];
        example1 = "> " + problems[problemNumber - 1]["example1"];
        example2 = "> " + problems[problemNumber - 1]["example2"];
        example3 = "> " + problems[problemNumber - 1]["example3"];
        answer = "> " + problems[problemNumber - 1]["answer"];
        soso = "> " + problems[problemNumber - 1]["soso"];

        TimeAttackController timeBar = timeBarImage.GetComponent<TimeAttackController>();
        if (timeBar)
        {
            timeBar.timeLeft = 3f;
        }
        else
        {
            Debug.Log("other script object error");
        }

        questionText.GetComponent<Text>().text = question;
        example1Text.GetComponent<Text>().text = example1;
        example2Text.GetComponent<Text>().text = example2;
        example3Text.GetComponent<Text>().text = example3;

        problemCount++;
    }

    // Update is called once per frame
    void Update()
    {
        TimeAttackController timeBar = timeBarImage.GetComponent<TimeAttackController>();
        if (timeBar)
        {
            if (timeBar.timeLeft <= 0)
            {
                NextOrOverCheck();
            }
        }
        else
        {
            Debug.LogError("other script object error");
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
        }
        else if (soso.Equals(example))
        {
            totalCorrect += 5;
            totalCorrectText.GetComponent<Text>().text = "호감도: " + totalCorrect.ToString();
            correctIncorrectText.GetComponent<Text>().text = "호감도 5 up";
        }
        else
        {
            totalCorrectText.GetComponent<Text>().text = "호감도: " + totalCorrect.ToString();
            correctIncorrectText.GetComponent<Text>().text = "호감도 0 up";
        }
        NextOrOverCheck();
    }

    public void NextOrOverCheck()
    {
        if (problemCount < 3)
        {
            problemNumber++;
            ShowProblem();
        }
        else
        {
            problemCount = 0;
            npcManager.npcGage[birdType] += totalCorrect;
            totalCorrect = 0;
            index ++;
            //Debug.Log("ShowGameOverBox");
            //questionText.SetActive(false);
            //example1Text.SetActive(false);
            //example2Text.SetActive(false);
            //example3Text.SetActive(false);
            //timeBarImage.SetActive(false);
            //gameOverPanel.SetActive(true);
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

}
