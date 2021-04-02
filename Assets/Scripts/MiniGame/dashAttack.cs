using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashAttack : MonoBehaviour
{
    public bool inputDashDwn = false; // dash버튼 눌렀을 때
    public bool inputDashUp = false; // dash버튼 떼었을 때
    public AudioSource dashBgm; // 효과음

    void Update()
    {
        // dash버튼 눌렀을 때 --- 
        if(inputDashDwn || Input.GetKeyDown("space")){
            PlayerMove.superTime = true; //무적타임 시작
            transform.Translate(0.9f,0,0); //x축에서 우측으로 이동
            dashBgm.Play(); //효과음 실행
            StartCoroutine(waitTime(0.2f)); //대기 코루틴
            inputDashDwn = false; //DashDwn 끝
        }

        // dash버튼 떼었을 때 --- 
        if(inputDashUp || Input.GetKeyUp("space")){
            transform.Translate(-0.9f,0,0); //x축 좌측으로 이동(좌표 원상복귀)
            PlayerMove.superTime = false; //무적타임 끝
            inputDashUp = false; //DashUp 끝
        }

    }

    IEnumerator waitTime(float time){
        //time만큼 대기
        yield return new WaitForSeconds(time);

        //무적타임이면서 피격타임이 아닐(=끝났을) 경우 -> 무적타임 끝
        if(PlayerMove.superTime && !PlayerMove.unBeatTime) PlayerMove.superTime = false;
    }

}
