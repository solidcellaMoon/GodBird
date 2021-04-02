using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{

    public int itemType; // 아이템 종류를 구분하기 위한 변수
    public float speed; // 아이템의 이동 스피드

    void Update()
    {
        if(lifeManager.lifeNum == 0) Destroy(gameObject); // 게임 오버시 삭제
        else{
                // 아이템은 화면에서 오른쪽->왼쪽 으로 이동
                transform.Translate(-1*speed*Time.deltaTime,0,0);

                // 화면 밖을 넘어가면 삭제
                if(transform.position.x < -4f) Destroy(gameObject);
                if(transform.position.y < -4f) Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        // 플레이어와 충돌하면 종류별 점수를 기록하고 삭제
            if(itemType == 0) scoreManager.beanScore += 1;
            if(itemType == 1) scoreManager.diceScore += 1;
            if(itemType == 2) lifeManager.lifeNum += 1;
            Destroy(gameObject);
    }
}
