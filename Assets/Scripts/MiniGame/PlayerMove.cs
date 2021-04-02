using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    public static bool superTime = false; // 무적 타임 여부
    public static bool unBeatTime = false; // 피격 불가 여부
    public bool inputUp = false; // up버튼 눌렀는지
    public bool inputDown = false; // down버튼 눌렀는지
    public static float distanceY = 0; // y축 이동 거리
    public AudioSource itemBgm, crashBgm; // 효과음
    Vector3 initPos; // 초기 위치


    void Start(){
        initPos = transform.position; //플레이어의 초기 위치
    }

    void Update () {
        //키보드 조작용 ---
        if(Input.GetKey("up")) distanceY = 0.7f;
        else if (Input.GetKey("down")) distanceY = -0.7f;

        // 상하 이동 범위 ---
        if(inputUp)  distanceY += 0.7f;
        else if(inputDown) distanceY =- 0.7f;

        // 해당 속도만큼 이동 ---
        distanceY *= Time.deltaTime * 8;
        transform.Translate(0,distanceY,0);

        moveRange(); // 플레이어 화면 이탈 방지 (이거 지우면안됨)
        distanceY = 0; // y축 거리 초기화
    }

    //플레이어 화면 이탈 방지---
    void moveRange(){
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if(pos.y < 0.2f) pos.y = 0.2f; // 화면 하단으로 이탈했을 때
        if(pos.y > 0.88f) pos.y = 0.88f; // 화면 상단으로 이탈했을 때

        // 위치 보정
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    //적과 충돌했을 때---
    void OnTriggerEnter2D(Collider2D collision){
        if(!superTime && !unBeatTime){ //일반: 무적타임(X) and 피격불가(x)
            crashBgm.Play(); // 충돌음 실행
            lifeManager.lifeNum--; // 생명 1만큼 감소
            unBeatTime = true; // 피격불가 시작
            StartCoroutine(UnBeatTime()); //피격불가 코루틴
        }
    }

    //아이템과 충돌했을 때---
    void OnCollisionEnter2D(Collision2D collision){
        itemBgm.Play(); //아이템 효과음 실행
    }

    //피격불가일 때---
    IEnumerator UnBeatTime(){
        int countTime = 0;

        if(lifeManager.lifeNum != 0){ // 생명이 0이 아니면 - 피격불가 애니메이션
            while(countTime < 10){ //애니메이션은 10초동안 지속

                // Alpha effect - 플레이어가 반투명하게 반짝임
                if(countTime%2 == 0) GetComponent<SpriteRenderer>().color = new Color32(255,255,255,90);
                else GetComponent<SpriteRenderer>().color = new Color32(255,255,255,180);

                // 0.1초 대기 후 countTime 증가
                yield return new WaitForSeconds(0.1f);
                countTime++;
            }
        }

        //effect end - 원상태로 돌아옴
        GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
        unBeatTime = false; //피격불가 끝

        yield return null;
    }

}
