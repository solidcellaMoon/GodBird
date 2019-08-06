using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerator : MonoBehaviour
{

    public GameObject beanPrefab, dicePrefab, heartPrefab;
    float span = 1.0f, delta = 0, time = 0.32f;
    public int px = 10; float py = 0;
    public int itemNum = 20; // 한번 시행에 생성되는 템 개수
    int heartLimit = 3; // 한 판에 3번까지만 하트 생성
    GameObject item;

    void Start(){
        time = 1;
    }


    // Update is called once per frame
    void Update()
    {
        

        // 게임 오버시
        if(lifeManager.lifeNum == 0){
            time = 1;
        } else {
            px = 10;

            this.delta += time*Time.deltaTime;
            if(this.delta > this.span){
                this.delta = 0;
                py += Random.Range(-2,3);
                makeItem(itemNum);
                time = 0.32f;
            }

        }
    }

    void makeItem(int num){
        for(int i = 0; i<num; i++){
            // 범위 조정
            if(py > 3.5f) py = (int) Random.Range(2,3);
            if(py < -3f) py = (int) Random.Range(-3,-1);

            // 확률적으로 주사위 생성 (기본은 콩)
            int whatIs = Random.Range(0,1000);
            if(whatIs > 970) //주사위 생성
                item = Instantiate(dicePrefab) as GameObject;
                
            else if(whatIs > 1) //콩 생성
                item = Instantiate(beanPrefab) as GameObject;
            
            else { // 하트 생성
                if(heartLimit > 0){
                    item = Instantiate(heartPrefab) as GameObject;
                    heartLimit --; }
                else item = Instantiate(dicePrefab) as GameObject;
            }

            item.transform.position = new Vector3(px,py,0);
            itemPos();

        }
    }

    void itemPos(){ // 생성좌표의 범위를 랜덤으로 조정한다.

        int type = Random.Range(0,141);

        px += 1; // x좌표는 한칸씩 뒤로

        if(type <= 90) py += 0; // 일렬
        else if(type <= 105) py += 1; // 한칸 위로
        else if (type <= 120) py -= 1; // 한칸 아래로
        else if (type <= 130) py += 2; // 두칸 위로
        else py -= 2; // 두칸 아래로

    }

}
