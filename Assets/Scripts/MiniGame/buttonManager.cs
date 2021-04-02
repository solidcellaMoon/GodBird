using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager : MonoBehaviour
{
    GameObject player; // 플레이어 오브젝트
    PlayerMove playerScript; // 플레이어 움직임 로직 스크립트
    dashAttack dashScript; // 공격모션 로직 스크립트

    public void Start(){
        // 캐릭터 오브젝트, 동작 관리 스크립트 불러오기
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMove> ();
        dashScript = player.GetComponent<dashAttack> ();
    }

    public void Update(){ 
        // 공격 - space 버튼이 눌렸는지 확인
        if(Input.GetKeyDown("space")) DashPressed();
        if(Input.GetKeyUp("space")) DashOff();
    }

    
    // 공격 모션 - dash버튼을 눌렸는지 여부를 확인---
    public void DashPressed(){
        dashScript.inputDashDwn = true; // dash버튼을 눌렀을 때
    }

    public void DashOff(){
        dashScript.inputDashUp = true; // dash버튼을 떼었을 때
    }

    // 상승 모션 - up버튼을 눌렀는지 여부를 확인---
    public void UpPressed(){
        playerScript.inputUp = true; // up버튼을 눌렀을 때
    }

    public void UpOff(){
        playerScript.inputUp = false; // up버튼을 떼었을 때
    }

    // 하강 모션 - down버튼을 눌렀는지 여부를 확인---
    public void DownPressed(){
        playerScript.inputDown = true; // down버튼을 눌렀을 때
    }

    public void DownOff(){
        playerScript.inputDown = false; // down버튼을 떼었을 때
    }

}
