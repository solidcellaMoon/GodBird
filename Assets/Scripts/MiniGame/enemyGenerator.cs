﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{

    public GameObject[] prefab = new GameObject [3];
    GameObject enemy;
    float span = 1.0f; float delta = 0; float time;
    public int px = 5; float py;
    Vector3 playerPos;

    void Start(){
        time = 0.2f;
    }

    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;

        this.delta += time*Time.deltaTime;
        if(this.delta > this.span){

            this.delta = 0;

            py = playerPos.y + posRange();
            if(py > 4.6f) py = 4.6f;
            if(py < -4.3f) py = -4.3f;

            SelectType();

            enemy.transform.position = new Vector3(px,py,0);

            time += 0.1f;
            // 최고 레벨 도달
            if(time > 3.6f) time = Random.Range(3f,4f);

        } 
    
        
    }

    void SelectType(){
        int who = Random.Range(0,101);

        if(who <= 75)
            enemy = Instantiate(prefab[0]) as GameObject;

        else if(who <= 95)
            enemy = Instantiate(prefab[1]) as GameObject;
            
        else{
                enemy = Instantiate(prefab[2]) as GameObject;
                py = Random.Range(3.5f,4.5f) * isPlus();
            }
    }

    float posRange(){ // y좌표 범위 조정 함수
        float range = Random.Range(-4f,4f);
        if (range <= abs(2.0f)) range = 3f*isPlus();
        return range;
    }

    float abs(float num){ // 절댓값 함수
        float result;
        if(num < 0) result = num * -1;
        else result = num;
        return result;
    }

    int isPlus(){ // 양수 OR 음수 설정 함수
        int isPlus = Random.Range(0,2);
        if(isPlus == 0) return 1;
        else return -1;
    }

}
