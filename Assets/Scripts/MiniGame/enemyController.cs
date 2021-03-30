using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public int enemyType; // 적의 타입을 int형으로 지정
    public float xSpeed, ySpeed; // x,y축 이동 스피드 (enemy마다 다름)
    public float delta; // 상하 이동 가능한 최대 길이
    public int sinSpeed; // 상하 이동 속도

    Vector3 playerPos, thisPos; // 플레이어의 위치, 해당 오브젝트의 위치
    Rigidbody2D rigid; // 충돌판정
    GameObject player; dashAttack dashScript; // 플레이어 오브젝트, 플레리어 공격 로직
    bool isDie; //적이 플레이어의 공격을 받으면 true, 그 외 false

    void Start(){ // 오브젝트 불러오기 및 변수 초기화
        player = GameObject.Find("Player");
        dashScript = player.GetComponent<dashAttack> ();
        rigid = gameObject.GetComponent<Rigidbody2D> ();
        isDie = false; // isDie는 false로 초기화
    }

    void Update()
    {
        //게임 오버시 삭제
        if(lifeManager.lifeNum == 0) Destroy(gameObject);

        else{

            if(!isDie){ //적이 죽지 않았다면
                switch(enemyType){ //적의 종류에 따른 움직임

                    case 1: //x축 방향으로 이동 ---
                    transform.Translate(xSpeed*Time.deltaTime,0,0); break;

                    case 2: //지그재그로 이동 --- sin함수
                    // delta, sinSpeed
                    transform.Translate(xSpeed*Time.deltaTime,
                    delta*Mathf.Sin(Time.time*sinSpeed),0);
                    break;

                    case 3: //플레이어 방향으로 돌진 ---
                    // ySpeed, playerPos, thisPos
                    Type3Move(); break;
                }
            }
            else Die(); //적이 죽었다면 범위 이탈시킴
            }

        //범위 이탈시 삭제
        if(transform.position.x < -4.5f || transform.position.y < -8f) Destroy(gameObject);
    }

    // 플레이어와 충돌 판정 ---
    void OnTriggerEnter2D(Collider2D collision){
        // 플레이어의 공격으로 충돌했는지 여부로 isDie를 수정
        if(PlayerMove.superTime) isDie = true; // 공격받아서 충돌
        else isDie = false;
    }

    // enemy 오브젝트가 공격을 받아 죽었을 때 ---
    void Die(){
        // 빠른 속도로 이탈 범위로 이동시킨 뒤 Update()의 코드에 의해 삭제
        float xSpeed = 5*Time.deltaTime;
        float ySpeed = -20*Time.deltaTime;
        transform.Translate(xSpeed,ySpeed,0);
    }

    // Type3Move(): 플레이어 방향으로 돌진하는 움직임 ---
    void Type3Move(){

        //플레이어의 위치 저장
        if(null != GameObject.Find("Player")){
            playerPos = GameObject.Find("Player").transform.position;
        }

        //해당 오브젝트의 위치 저장
        thisPos = this.transform.position;

        //플레이어를 향하는 x축 방향으로 이동
        transform.Translate(-4*Time.deltaTime,0,0);

        if(thisPos.x <= 2.2f){ // 오브젝트가 화면에 안보이는 위치
            transform.Translate(xSpeed*Time.deltaTime,0,0); //x스피드로 이동

            if(thisPos.x >= -0.3f){ // 오브젝트가 화면에 나타나는 위치
                // 플레이어의 y좌표와 비교한 뒤, 플레이어의 위치와 가까워지도록 함
                if(thisPos.y > playerPos.y) transform.Translate(0,ySpeed,0);
                else transform.Translate(0,ySpeed*(-1),0); 
            }
        }

    }

}
