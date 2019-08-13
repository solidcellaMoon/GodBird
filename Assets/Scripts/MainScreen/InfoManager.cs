using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public Image npcImg;
    public Text nameTxt, spaceTxt, abilityTxt, gageTxt, infoTxt;
    public static int type = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(type != -1)
        if(!npcManager.npcList[type]) npcImg.color = Color.black;
        else npcImg.color = Color.white;

        npcImg.sprite = Resources.Load<Sprite>("bird_"+type.ToString()) as Sprite;

        InfoUpdate();

        if(type != -1 && !npcManager.npcList[type]) {
            nameTxt.text = "???";
            infoTxt.text = "";
        }

    }

    void InfoUpdate(){
        switch(type){
            case 0: nameTxt.text = "까마귀";
            spaceTxt.text = "출현 장소:\n잔디공원, 회색도심";
            abilityTxt.text = "능력: 신도 2배 증가";
            gageTxt.text = "호감도: " + npcManager.npcGage[type].ToString()+"/100";
            infoTxt.text = "까치와 소꿉친구 사이이다.\n" +
            "취준생 생활을 오래 하느라 주변인들과의 교류가 단절되었다. " +
            "알바해서 번 돈으로 생활하고 있다."; break;

            case 1: nameTxt.text = "병아리";
            spaceTxt.text = "출현 장소:\n잔디공원, 바름배움촌";
            abilityTxt.text = "능력: 신도 2배 증가";
            gageTxt.text = "호감도: " + npcManager.npcGage[type].ToString()+"/100";
            infoTxt.text = "인기스타 오목눈이의 팬이다.\n" +
            "SNS를 해서 또래 팔로워들에게\n영향력이 있는 모양이다.\n" +
            "하지만 수입은 용돈뿐이다."; break;

            case 2: nameTxt.text = "비둘기 노부부";
            spaceTxt.text = "출현 장소:\n바름배움촌, 회색도심";
            abilityTxt.text = "능력: 신도 3배 증가";
            gageTxt.text = "호감도: " + npcManager.npcGage[type].ToString()+"/100";
            infoTxt.text = "마을 주민들에게 항상 친절하고 둘이 굉장히 닮았다. " +
            "둘기둘이 반찬가게를 운영하며 오랫동안 가게 운영을 하면서 " +
            "모아놓은 자산이 꽤 있는 듯하다."; break;

            case 3: nameTxt.text = "펭귄";
            spaceTxt.text = "출현 장소:\n야자바다, 북극설원";
            abilityTxt.text = "능력: 신도 4배 증가";
            gageTxt.text = "호감도: " + npcManager.npcGage[type].ToString()+"/100";
            infoTxt.text = "핫팩 사업에 성공해 젊은 나이에 많은 돈을 벌었다. " +
            "말 시키는 걸 귀찮아 하고 자기 중심적이다. " +
            "자신의 고향에 있는 가족과 친구들하고만 교류하고 있다."; break;

            case 4: nameTxt.text = "앵무새";
            spaceTxt.text = "출현 장소:\n야자바다, 정글숲";
            abilityTxt.text = "능력: 신도 5배 증가";
            gageTxt.text = "호감도: " + npcManager.npcGage[type].ToString()+"/100";
            infoTxt.text = "유학 와서 아직 말이 서투르다.\n" +
            "여행을 많이 다녀서 친구가 많고 굉장히 발이 넓다. " +
            "새들의 호감을 사는 성격이다."; break;

            case 5: nameTxt.text = "어깨걸이 극락조";
            spaceTxt.text = "출현 장소:\n정글숲, 북극설원";
            abilityTxt.text = "능력: 신도 5배 증가";
            gageTxt.text = "호감도: " + npcManager.npcGage[type].ToString()+"/100";
            infoTxt.text = "방구석 폐인에 이상한 말투를 구사한다. " +
            "자신을 이해해주는 새에게 더 호감을 느끼고 잘해준다. " +
            "집에만 박혀서 놀고 먹기만 하는 듯하나, 인터넷에서 유명하다는 소문이 있다."; 
            break;

            default: nameTxt.text = "???"; spaceTxt.text = "출현 장소:\n???";
            abilityTxt.text = "능력: ???"; gageTxt.text = "호감도: 0/100";
            infoTxt.text = ""; break;
        }
    }

}
