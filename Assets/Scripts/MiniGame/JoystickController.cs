using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour
{
    // 공개
    public Transform Stick;         // 조이스틱.
    public GameObject player; // 플레이어 오브젝트
    PlayerMove playerScript; // 플레이어 움직임 로직 스크립트

    // 비공개
    private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
    private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
    private float Radius;           // 조이스틱 배경의 반 지름.
    private bool MoveFlag;          // 플레이어 움직임 스위치.

    void Start()
    {
        //player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMove>();

        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        // 캔버스 크기에대한 반지름 조절.
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;

        MoveFlag = false;
    }
    /*
    void Update()
    {
        if (MoveFlag)
            player.transform.transform.Translate(Vector3.forward * Time.deltaTime * 10f);
    }*/

    // 드래그
    public void Drag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
        JoyVec = (Pos - StickFirstPos).normalized;

        // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        //Outer Pad 영역을 벗어나지 않도록 제한
        if (Dis > 100f) Dis = 100f;

        //y축으로만 이동
        Vector3 ClipDis = new Vector3(JoyVec.x, JoyVec.y * Dis, JoyVec.z);

        Stick.position = StickFirstPos + ClipDis;

        //상승 모션 - up버튼을 눌렀는지 여부를 확인-- -
        if (JoyVec.y > 0.5) // up버튼을 눌렀을 때
        {
            playerScript.inputUp = true;
            playerScript.inputDown = false;

        }
        else if (JoyVec.y < -0.5) // down버튼을 눌렀을 때
        {
            playerScript.inputUp = false;
            playerScript.inputDown = true;

        }
        else
        {
            playerScript.inputUp = false;
            playerScript.inputDown = false;
        }
    }

    // 드래그 끝.
    public void DragEnd()
    {
        Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        JoyVec = Vector3.zero;          // 방향을 0으로.
        MoveFlag = false;
        playerScript.inputUp = false;
        playerScript.inputDown = false;
    }
}