using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public int enemyType; // 타입 구분 변수

    public float xSpeed;
    public float delta; // 상하 이동 가능 최대 길이
    public int sinSpeed; // 상하 이동 속도
    public float ySpeed; 
    Vector3 playerPos, thisPos;
    Rigidbody2D rigid;
    bool isDie;
    GameObject player; dashAttack dashScript;

    void Start(){
        player = GameObject.Find("Player");
        dashScript = player.GetComponent<dashAttack> ();
        rigid = gameObject.GetComponent<Rigidbody2D> ();
        isDie = false;
    }

    void Update()
    {
        // 게임 오버시 삭제
        if(lifeManager.lifeNum == 0) Destroy(gameObject);
        else{
        if(!isDie){
            //xSpeed *= Time.deltaTime;
        switch(enemyType){
            case 1: // x축 방향으로 이동한다.
            transform.Translate(xSpeed*Time.deltaTime,0,0); break;

            case 2: // 지그재그로 이동한다.
            // delta, sinSpeed
            transform.Translate(xSpeed*Time.deltaTime,delta*Mathf.Sin(Time.time*sinSpeed),0);
            break;

            case 3: // 플레이어 방향으로 돌진한다.
            // ySpeed, playerPos, thisPos
            Type3Move(); break;
            }
        }
        else Die();}

    // 범위 이탈시 삭제
        if(transform.position.x < -4.5f
        || transform.position.y < -8f) Destroy(gameObject);
    }

    void Type3Move(){
        if(null != GameObject.Find("Player"))
        playerPos = GameObject.Find("Player").transform.position;

        thisPos = this.transform.position;

        transform.Translate(-4*Time.deltaTime,0,0);

        if(thisPos.x <= 2.2f){
            transform.Translate(xSpeed*Time.deltaTime,0,0);
            if(thisPos.x >= -0.3f){
            if(thisPos.y > playerPos.y) transform.Translate(0,ySpeed,0);
            else transform.Translate(0,ySpeed*(-1),0); 
            }
            
        }

    }

        void OnTriggerEnter2D(Collider2D collision){

        if(PlayerMove.superTime == true && PlayerMove.unBeatTime == false) {
            isDie = true;
        }
        if(PlayerMove.unBeatTime == true && dashScript.inputDashDwn) isDie = true;
        
    }

    void Die(){
        float xSpeed = 5*Time.deltaTime;
        float ySpeed = -20*Time.deltaTime;
        transform.Translate(xSpeed,ySpeed,0);
    }

}
