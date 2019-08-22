using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMover : MonoBehaviour
{
    public Rigidbody cube;
    public int type;
    // 0: 까마귀 / 1: 병아리 / 2: 비둘기
    // 3: 펭귄 / 4: 앵무새 / 5: 어깨걸이 / 6: 까치(주인공)
    // 3, 5번은 날지 못함.
    Vector3 dir, nowPos;
    int rand;
    float dir1, dir2;
    bool reStart = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        float xPos = Random.Range(-3f, 3f);
        float yPos = Random.Range(-2.7f,1.5f);
        float zPos = transform.position.z;
        if(type == 3 || type == 5) yPos = -2.76f;
        transform.position = new Vector3(xPos, yPos, zPos);
        WhatType();
        if(type == 3 || type == 5) NormalMotion();
        else FlyMotion();
        StartCoroutine(Move());
    }

    IEnumerator Move(){

        while(true){

            dir1 = Random.Range(-1f,1f);
            dir2 = Random.Range(2f,4f);

            float randTime = Random.Range(2f,5f);

            yield return new WaitForSeconds(randTime);

            Direction();

            rand = Random.Range(0,2);
            if(type == 3 || type == 5){
                // 날지 못하는 경우
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir1,0);
            }
            else { // 그 외 날 수 있는 경우
                if(rand == 0){ // 날기
                    FlyMotion();
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir1,dir2);
                    int randFly = Random.Range(0,2);
                    for(int i = 0; i < randFly; i++){
                       yield return new WaitForSeconds(0.5f);
                       gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f*dir1,dir2);
                    }
                }
                else { // 걷기
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir1,0);
                }
            }

        }
    }

    void Direction(){
        
         // 이동방향에 따라 시선 바꾸기
         dir = transform.localScale;

        if(type == 6) { // 까치일 때

            if(dir1 < 0) dir.x = -Mathf.Abs(dir.x);
            else dir.x = Mathf.Abs(dir.x);

        } else{ //까치가 아닐 때

            if(dir1 > 0) dir.x = -Mathf.Abs(dir.x);
            else dir.x = Mathf.Abs(dir.x);
        }

        transform.localScale = dir;

    }

    void WhatType(){
        switch(type){
            case 0: type = 0; break;
            case 1: type = 1; break;
            case 2: type = 2; break;
            case 3: type = 3; break; // 못날음
            case 4: type = 4; break;
            case 5: type = 5; break; // 못날음
            default: type = 6; break;
        }
    }

    void FlyMotion(){
        // 날기 모션
        gameObject.GetComponent<Animator>().runtimeAnimatorController = 
        Resources.Load<RuntimeAnimatorController>("anime/fly_"+type.ToString())
        as RuntimeAnimatorController;
    }

    void NormalMotion(){
        // 평소 모션
        gameObject.GetComponent<Animator>().runtimeAnimatorController = 
        Resources.Load<RuntimeAnimatorController>("anime/bird_"+type.ToString())
        as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        moveRange();
        nowPos = gameObject.transform.position;
    }

    void moveRange(){
     Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
     if(pos.y < 0.2f) pos.y = 0.2f; // down OUT
     if(pos.y > 0.88f) pos.y = 0.88f; // up OUT
     if(pos.x > 1.05f) pos.x = 1.05f;
     if(pos.x < -0.05f) pos.x = -0.05f;
     transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void OnCollisionEnter2D(Collision2D col){
        NormalMotion();
    }
}
