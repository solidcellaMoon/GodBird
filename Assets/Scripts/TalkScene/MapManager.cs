using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static GameObject[] map = new GameObject [4];
    // 잔디공원, 바름배움촌, 회색도심, 야자바다, 정글숲, 북극설원 
    // 총 6가지 맵 존재
    public static bool talkStart;
    public static float speed = 3; // 이동 스피드
    public Transform startPoint;
    public Transform endPoint;
    public static bool check = false; // ?
    public static int index = 0; // 배열 확인용인듯 함
    public GameObject npcPos;
    int cnt = 0;

    public GameObject Canvas, DialManager;
    public static int birdType;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++){
            //map[i] = GameObject.Find("바름배움촌");
            map[i] = GameObject.Find(RandomCourse.placeNow[i].name);
            // 비활성화 오브젝트는 Find로 못찾음.....
            // 비활성화된걸 찾는 방법도 있긴 있던데 적용이 다 안돼서
            // 일단 맵 오브젝트들을 전부 활성화 시킨 상태로 검색
        }
        map[index].transform.position = startPoint.position;
        // 첫시작 맵 = 배열 첫 원소
        map[index].SetActive(true); // 첫시작 맵을 지나감
        birdSelect();

    }

    // Update is called once per frame
    void Update()
    {

        if (map[index].transform.position.x >= endPoint.position.x && check == false)
        {
            map[index].transform.Translate(-1f * speed * Time.deltaTime, 0, 0);
        //StartCoroutine(countTime());
            
        if(!DialManager.activeSelf) speed = 3;
        //speed = 3;
/*
            if(map[index].transform.position.x < -10.5f){
                speed = 0;
                // 중간지점일 때 멈춤.
                // 대화 기능 오픈
                Canvas.SetActive(true);
                DialManager.SetActive(true);
                // 대화시작
            }
 */

        
            
            
            //map[index].transform.Translate(-0.8f * speed * Time.deltaTime, 0, 0);
            // 맵 이동을 보여주는 과정 
        }


        else if (check == false)
        {
            //map[index].SetActive(false);
            map[index].transform.position = startPoint.position;

            if (index == map.Length - 1)
            {
                check = true;
            }


            //배열 길이보다 작으면 순서 +1
            else index++;
            birdSelect();
            switch(birdType){
                case 0: case 1: case 2: 
                npcPos.transform.position = new Vector3 (14.87f,1.94f,0); break;
                case 3: case 4:
                npcPos.transform.position = new Vector3 (14.87f,2,0); break;
                case 5:
                npcPos.transform.position = new Vector3 (14.87f,1.87f,0); break;
            }



            map[index].transform.position = startPoint.position;
            //map[index].SetActive(true);
        }

        if(check){
            check = false;
            index = 0;
            SceneManager.LoadScene("eventScene");
        }

    }
    void birdSelect(){
        switch(MapChecker.mapOutput[index]){
            case 0: // 잔디공원
            birdType = Random.Range(0,2); break;
            case 1: // 바름배움촌
            birdType = Random.Range(1,3); break;
            case 2: // 회색도심
            birdType = Random.Range(0,2); if(birdType == 1) birdType = 2;  break;
            case 3: // 야자바다
            birdType = Random.Range(3,5); break;
            case 4: // 정글숲
            birdType = Random.Range(4,6); break;
            case 5: // 북극설원
            birdType = Random.Range(3,5); if(birdType == 3) birdType = 5; break;
        }
    }
}
