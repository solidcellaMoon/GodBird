using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerator : MonoBehaviour
{
    public GameObject[] prefab = new GameObject [3]; //아이템 프리팹 리스트
    GameObject item; //아이템 오브젝트
    float span, delta, timeGap; //생성 시간 관리 변수
    public int px; float py = 0; // 아이템 생성 위치 (x,y) 좌표
    public int itemNum; // 한번 시행에 생성되는 템 개수
    int heartLimit = 3; // 한 판에 3번까지만 하트 생성


    void Start(){
        span = 1.0f;
        delta = 0;
        timeGap = 0.25f; //초기 생성 시간 간격
    }


    void Update()
    {
        //아이템 생성 위치에 아이템 생성 ---
        px = 10; //x좌표는 10으로 고정
        this.delta += timeGap*Time.deltaTime;
        
        if(this.delta > this.span){
                this.delta = 0;
                py += Random.Range(-2,3); //y좌표는 -2~2 범위
                makeItem(itemNum); //itemNum개의 아이템을 생성
                timeGap = 0.32f; //다음 생성까지의 시간 간격
        }
    }

    //makeItem(int num): 아이템 생성 함수 --- 
    void makeItem(int num){
        for(int i = 0; i<num; i++){
            //  y축 좌표 조정
            if(py > 3.5f) py = (int) Random.Range(2,3);
            if(py < -3f) py = (int) Random.Range(-3,-1);

            // 0~1000까지의 수를 뽑아, 확률적으로 아이템 생성
            int itemType = Random.Range(0,1000);

            //주사위 생성 ---
            if(itemType > 970) item = Instantiate(prefab[1]) as GameObject;
                
            //콩 생성 ---
            else if(itemType > 1) item = Instantiate(prefab[0]) as GameObject;
            
            //하트 생성 ---
            else {
                if(heartLimit > 0){
                    // 하트 제한 횟수(3번)까지만 하트를 생성
                    item = Instantiate(prefab[2]) as GameObject;
                    heartLimit --; 
                    }
                else item = Instantiate(prefab[1]) as GameObject;
                // 제한 횟수를 넘으면, 하트가 아니라 주사위 아이템을 생성
            }

            //아이템 표시 위치 조정
            itemPos();

            //아이템 좌표 설정
            item.transform.position = new Vector3(px,py,0);
        }
    }

    //itemPos(): 생성좌표의 범위를 랜덤으로 조정 ---
    void itemPos(){
        int pyType = Random.Range(0,141); // 랜덤으로 y좌표 위치를 선택

        px += 1; // x좌표는 한칸씩 뒤로

        if(pyType <= 90) py += 0; // 일직선으로 생성
        else if(pyType <= 105) py += 1; // 한칸 위에 생성
        else if (pyType <= 120) py -= 1; // 한칸 아래에 생성
        else if (pyType <= 130) py += 2; // 두칸 위에 생성
        else py -= 2; // 두칸 아래에 생성

    }
}
