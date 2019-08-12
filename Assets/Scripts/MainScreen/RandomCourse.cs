using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

/*하려다가 못한 것
 * 장소별 확률 설정->x(안하기로 함)
 * 주사위, 리셋 버튼 누르면 팝업창 나와서 확인가능하게
 * 외출->도감->외출 일때 정보 리로드되는 것 해결*/


//장소 정보 구조체
public struct placeInfo
{
    public string name;           // 장소이름
    public int cost;              // 비용
    public int dice;              // 주사위값

    public placeInfo(string name, int cost, int dice)  //생성자
    {
        this.name = name;
        this.cost = cost;
        this.dice = dice;
    }
}
public class RandomCourse : MonoBehaviour
{
    //장소 정보 입력
    private placeInfo[] placeList = new placeInfo[]
    {
        new placeInfo("잔디공원",0,1),
        new placeInfo("바름배움촌",1,2),
        new placeInfo("회색도심",2,3),
        new placeInfo("야자바다",3,4),
        new placeInfo("정글숲",4,5),
        new placeInfo("북극설원",5,6)
    };
    //현재 뽑힌 장소 정보 리스트(계속 갱신)
    private placeInfo[] placeNow = new placeInfo[4];

    //현재 코스 4개의 장소 이름 텍스트 오브젝트 리스트(계속 갱신)
    [SerializeField] private Text[] txt_place;
    //현재 코스 4개의 장소 비용 텍스트 오브젝트 리스트(계속 갱신)
    [SerializeField] private Text[] txt_cost;
    //보유 주사위 개수 정보 텍스트 오브젝트(계속 갱신)
    [SerializeField] private Text txt_diceNum;
    //보유 콩 개수 정보 텍스트 오브젝트(계속 갱신)
    [SerializeField] private Text txt_beanNum;
    //주사위 굴리는 비용(콩) 변수
    [SerializeField] private int diceCost;
    //주사위 없고 콩으로 주사위 구매한 횟수 변수
    [SerializeField] private int clickcount = 0;

    //주사위 버튼 이름 리스트(맞춰보기용)
    [SerializeField] private string[] DiceButton = { "dice reset1", "dice reset2", "dice reset3", "dice reset4" };
    //리셋 버튼 이름 리스트(맞춰보기용)
    [SerializeField] private string[] ResetButton = { "reset1", "reset2", "reset3", "reset4" };

    public int randomNumber;  //난수
    //GameManager에서 보유 주사위 개수 정보 가져옴(정수)
    public int DiceNum = itemManager.diceNum;
    //GameManager에서 보유 콩 개수 정보 가져옴(정수)
    public int BeanNum = itemManager.beanNum;
    //클릭한 주사위 버튼을 숫자로 담는 변수
    public int rolling_dice;
    //클릭한 리셋 버튼을 숫자로 담는 변수
    public int press_reset;

    public void placeNow_renew(int num1, int num2)
    {
        placeNow[num1].name = placeList[num2].name;
        placeNow[num1].cost = placeList[num2].cost;
        placeNow[num1].dice = placeList[num2].dice;

        txt_place[num1].text = placeNow[num1].name;
        txt_cost[num1].text = placeNow[num1].cost + "콩 소모";
    }
    //위아래 장소와 겹치는지 비교(whichDice는 굴린 주사위의 위치(0~3),최종적으로는 randnum을 리턴)
    public int checkRepeatedPlace(int whichDice)
    {
        int randnum = Random.Range(0, placeList.Length);

        //0번 코스는 아래 코스와 안겹치도록 비교, 3번 코스는 위 코스와 안겹치도록 비교, 나머지 코스는 위 아래 다 비교해야(코스 0~3)
        switch (whichDice)
        {
            case 0:
                while (randnum != 0 && placeList[randnum].dice == placeNow[whichDice + 1].dice)
                {
                    randnum = Random.Range(0, placeList.Length);
                }
                break;
            case 3:
                while (randnum != 0 && placeList[randnum].dice == placeNow[whichDice - 1].dice)
                {
                    randnum = Random.Range(0, placeList.Length);
                }
                break;
            default:
                while (randnum != 0 && (placeList[randnum].dice == placeNow[whichDice - 1].dice || placeList[randnum].dice == placeNow[whichDice + 1].dice))
                {
                    randnum = Random.Range(0, placeList.Length);
                }
                break;
        }  //주사위 누른 것에 대한 randomNumber결정 완료

        return randnum;
    }


    // Start is called before the first frame update
    void Start()
    {
        txt_diceNum.text = ": " + DiceNum.ToString();
        txt_beanNum.text = ": " + BeanNum.ToString();

        //0번째 코스 정보 랜덤 로드
        randomNumber = Random.Range(0, placeList.Length);
        placeNow_renew(0, randomNumber);

        //1번째~3번째 코스 정보 랜덤 로드
        for (int i = 1; i < txt_place.Length; i++)
        {
            randomNumber = Random.Range(0, placeList.Length);

            //연속으로 같은 장소가 나오지 않게 비교
            if (randomNumber == 0 || placeList[randomNumber].dice != placeNow[i - 1].dice)
            {
                placeNow_renew(i, randomNumber);
            }
            //연속으로 같은 장소가 나오면 다시 뽑기
            else
            {
                i -= 1;
            }
        }
    }

    //주사위 버튼으로 장소 변경
    public void Dice_Change()
    {
        //굴린 주사위 이름 체크
        string dice_button_name = EventSystem.current.currentSelectedGameObject.name;
        //굴린 주사위의 이름에 해당하는 주사위의 번호 찾기
        for (int i = 0; i < DiceButton.Length; i++)
        {
            if (dice_button_name == DiceButton[i])
            {
                rolling_dice = i;
            }
        }
        //보유중인 주사위, 콩 수 갱신
        DiceNum = itemManager.diceNum;
        BeanNum = itemManager.beanNum;

        diceCost = 5 * (clickcount + 1);

        //주사위가 1개 이상 있으면 코스 변경 가능(없으면 돈내고 바꿔야)
        if (DiceNum > 0)
        {
            //위아래 겹치는 장소 없는지 체크해서 최종 장소 결정
            randomNumber = checkRepeatedPlace(rolling_dice);
            //해당 randomNumber를 넣어서 바뀐 장소 정보 갱신
            placeNow_renew(rolling_dice, randomNumber);
            //주사위 개수 갱신
            DiceNum = DiceNum - 1;
            txt_diceNum.text = ": " + DiceNum.ToString();
            //바로 GameManager에도 갱신
            itemManager.diceNum = DiceNum;
        }
        //주사위가 없다면 돈내고 코스 변경
        else
        {
            if (BeanNum > diceCost)
            {
                //위아래 겹치는 장소 없는지 체크해서 최종 장소 결정
                randomNumber = checkRepeatedPlace(rolling_dice);
                //해당 randomNumber를 넣어서 바뀐 장소 정보 갱신
                placeNow_renew(rolling_dice, randomNumber);
                //콩 개수 갱신
                BeanNum = BeanNum - diceCost;
                txt_beanNum.text = ": " + BeanNum.ToString();
                //바로 GameManager에도 갱신
                itemManager.beanNum = BeanNum;
                clickcount = clickcount + 1;
            }
        }
    }

    //리셋 버튼으로 장소 초기화(무조건 잔디공원, 주사위 등의 재화 소모 없음)
    public void Reset()
    {
        //누른 리셋버튼 이름 체크
        string reset_button_name = EventSystem.current.currentSelectedGameObject.name;
        //누른 리셋버튼의 이름에 해당하는 리셋버튼의 번호 찾기
        for (int i = 0; i < ResetButton.Length; i++)
        {
            if (reset_button_name == ResetButton[i])
            {
                press_reset = i;
            }
        }
        placeNow_renew(press_reset, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
