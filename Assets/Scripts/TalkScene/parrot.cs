﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parrot : MonoBehaviour
{
    public Dictionary<string, string>[] parrotDic = new Dictionary<string, string>[46];

    public string[,] parrotStr = new string[45, 7]
    {
        {
            "Annyung!\nNan Aeng mu sae ya!\nNeo nun~?",
            "좋은 아침!",
            "안녕~",
            "난 까치야!",
            "난 까치야!",
            "안녕~",
            "유황앵무새를 만났다.\n앵무새는 여러 나라를 여행하는\n사교적인 새이다."
        },
        {
            "Neo kkongji git e\ncham meut jji da!",
            "나도 반가워~",
            "하하. 너도 멋져~",
            "그냥 산책하고 있았어.",
            "하하. 너도 멋져~",
            "나도 반가워~",
            "유황앵무새를 만났다.\n앵무새는 여러 나라를 여행하는 사교적인 새이다."
        },
        {
            "Daum e ddo boja chin gu~~!",
            "잘 가~",
            "고마워!",
            "그래 좋아.",
            "그래 좋아.",
            "잘 가~",
            "유황앵무새를 만났다.\n앵무새는 여러 나라를 여행하는 사교적인 새이다."
        },
        {
            "Yeogiseo mo hae~?",
            "나는 바람 쐬러 나왔어.",
            "뭐라고?",
            "여긴 웬일이야?",
            "나는 바람 쐬러 나왔어.",
            "여긴 웬일이야?",
            "공원에서 앵무새를 만났다.\n친근하게 말을 걸어온다."
        },
        {
            "Nanun oranmane\njajeon geo\ntareo nawat zi.",
            "비가 많이 오는데.",
            "좋은 취미를 가졌네!",
            "눈이 부셔서~",
            "비가 많이 오는데.",
            "좋은 취미를 가졌네!",
            "공원에서 앵무새를 만났다.\n친근하게 말을 걸어온다."
        },
        {
            "Yeok si bicycle\nbi olttae taya jam itzy~",
            "저쪽으로 가면 있어!",
            "흠, 나는 그다지…",
            "그래 좋아!",
            "흠, 나는 그다지…",
            "그래 좋아!",
            "공원에서 앵무새를 만났다.\n친근하게 말을 걸어온다."
        },
        {
            "Ba bbe da ba bba!!\nKun il e ya~~",
            "헐 어떡해?",
            "무슨 일이야?",
            "안녕 친구~",
            "무슨 일이야?",
            "안녕 친구~",
            "길에서 앵무새를 만났다.\n다급해 보인다."
        },
        {
            "Onul kka ji\nzzak mart sale handagu~",
            "수리공을 부르는 게 낫지 않을까?",
            "하하. 나도 알고 있어.",
            "두루마리 휴지 미리 사놔야겠다.",
            "두루마리 휴지 미리 사놔야겠다.",
            "하하. 나도 알고 있어.",
            "길에서 앵무새를 만났다.\n다급해 보인다."
        },
        {
            "Neoga pilyo han geotdo sada julgae\nif you want!",
            "나도 금방 갈 거라 괜찮아~",
            "나는 별로 필요 없어.",
            "우리 집은 깨끗한 걸.",
            "나도 금방 갈 거라 괜찮아~",
            "나는 별로 필요 없어.",
            "길에서 앵무새를 만났다.\n다급해 보인다."
        },
        {
            "Yeogi jiyeok language\nneomu aryeoweo…",
            "너만 그런 거 아니니까 걱정 마!",
            "나도 이사 온 지 얼마 안됐어!",
            "글쎄, 나는 여기 오래 살았어서.",
            "너만 그런 거 아니니까 걱정 마!",
            "글쎄, 나는 여기 오래 살았어서.",
            "길에서 앵무새를 만났다.\n고민이 있는 것 같다."
        },
        {
            "Hakwon en danigi silen girl~",
            "아마 귀여운 인형이 좋지 않을까?",
            "하하, 그럴 나이지.",
            "내 친구 병아리랑 똑같네~",
            "내 친구 병아리랑 똑같네~",
            "하하, 그럴 나이지.",
            "길에서 앵무새를 만났다.\n고민이 있는 것 같다."
        },
        {
            "Gen chana!\nNanun chocheonjae\njjang-jjang man~~",
            "이 정도로 뭘~",
            "넌 정말 재미있는 친구구나!",
            "힘내! 잘 될 거야.",
            "넌 정말 재미있는 친구구나!",
            "힘내! 잘 될 거야.",
            "길에서 앵무새를 만났다.\n고민이 있는 것 같다."
        },
        {
            "You odi ga?\nge strange yeabaedang?",
            "우리는 신성한 종교라굿!",
            "매일 기도드리러 가는 거야.",
            "너도 충분히 할 수 있어.",
            "매일 기도드리러 가는 거야.",
            "우리는 신성한 종교라굿!",
            "예배당 앞에서 앵무새를 만났다.\n호기심 가득한 표정으로 쳐다본다."
        },
        {
            "Nado neoga mo hanun ji gunggums~~",
            "너는 종교활동 안해?",
            "보여주는 거야 어렵지 않지!",
            "같이 일요일마다 가자.",
            "보여주는 거야 어렵지 않지!",
            "같이 일요일마다 가자.",
            "예배당 앞에서 앵무새를 만났다.\n호기심 가득한 표정으로 쳐다본다."
        },
        {
            "There will be jam!\nYeol sim hi halgae!!",
            "다음주 수요일 어때?",
            "우리 예배당은 먹을 것도 많이 줘!",
            "아주 좋은 자세야ㅎㅎ",
            "아주 좋은 자세야ㅎㅎ",
            "다음주 수요일 어때?",
            "예배당 앞에서 앵무새를 만났다. 호기심 가득한 표정으로 쳐다본다."
        },
        {
            "Oneul jeomsim\nmwo meng eoss eo?",
            "피자! 피자! 피자!\n먹고 싶다...",
            "난 아직 못 먹었지,,,",
            "우리 예배당가서 먹을래?",
            "난 아직 못 먹었지,,,",
            "피자! 피자! 피자!\n먹고 싶다...",
            "길에서 앵무새를 만났다.\n배고파 보이는 표정이다."
        },
        {
            "Geuleom mwo meng eullae?",
            "난 피곤해서 이제 갈래.",
            "이 앞에 파스타집은 어때?",
            "나 화장실 좀,,",
            "이 앞에 파스타집은 어때?",
            "난 피곤해서 이제 갈래.",
            "길에서 앵무새를 만났다.\n 배고파 보이는 표정이다."
        },
        {
            "Dessert do mengja!!!",
            "휴,, 너무 덥다~~",
            "배 터질거 같아서 싫어!",
            "그래! 커피 한잔 콜?",
            "그래! 커피 한잔 콜?",
            "배 터질거 같아서 싫어!",
            "길에서 앵무새를 만났다.\n 배고파 보이는 표정이다."
        },
        {
            "Travel kkeut!!!\nPresent sawasseo~",
            "헉!! 너무 고마워~~",
            "흠.. 난 좀 까다로운 편인데..",
            "여행? 완전 좋지~!",
            "헉!! 너무 고마워~~",
            "흠.. 난 좀 까다로운 편인데..",
            "앵무새를 만났다.\n즐거운 표정으로 반겨준다."
        },
        {
            "Pictures~\njom bollae?",
            "오홍홍.. 오홍홍..",
            "우와! 멋있다!",
            "조금만 보여줘~",
            "우와! 멋있다!",
            "조금만 보여줘~",
            "앵무새가 즐거운 표정으로 반겨준다."
        },
        {
            "Na neomu Pigons pigons~\nNa ije galge",
            "그러든지 말든지.",
            "잘가! 고마워 오늘!",
            "하.. 난 배고파..",
            "잘가! 고마워 오늘!",
            "그러든지 말든지.",
            "앵무새가 즐거운 표정으로 반겨준다."
        },
        {
            "Hu...\nneomu neomu difficult...TT",
            "무슨 일인데??",
            "어려울 게 있을까?",
            "난 쉬운데 헤헤...",
            "무슨 일인데??",
            "어려울 게 있을까?",
            "걸어가다 앵무새를 만났다.\n걱정이 많은 표정이다."
        },
        {
            "Chinguga siheom\ndung-mang haeseo wilohalyeogo..",
            "굳이...?",
            "술 한잔...?",
            "음.. 그냥 같이 있어줘.",
            "음.. 그냥 같이 있어줘.",
            "술 한잔...?",
            "걸어가다 앵무새를 만났다.\n 걱정이 많은 표정이다."
        },
        {
            "Nae\nheart apeuda!\napa!",
            "다 괜찮을 거야!!",
            "그런 니가 좋아~",
            "ㅎ~그래? 왜지?",
            "다 괜찮을 거야!!",
            "그런 니가 좋아~",
            "걸어가다 앵무새를 만났다.\n 걱정이 많은 표정이다."
        },
        {
            "Wow! Olaenman!!\nJal jinaesseo?",
            "응! 당연하지! 너는??",
            "난 요즘 너무 졸리더라..",
            "잘은 아니고 그냥 지냈지...",
            "응! 당연하지! 너는??",
            "잘은 아니고 그냥 지냈지...",
            "앵무새 집 근처에서\n앵무새를 발견했다.\n분주하게 움직이고 있다."
        },
        {
            "Nan naeil yeohaeng gaseo\njim ssaneun jung!",
            "또 가는 거야? 돈도 많다..",
            "우와! 어디로 가는데?",
            "난 방콕중인데!ㅜㅜ",
            "우와! 어디로 가는데?",
            "또 가는 거야? 돈도 많다..",
            "앵무새 집 근처에서 앵무새를 발견했다.\n 분주하게 움직이고 있다."
        },
        {
            "Korea-e saedeul I manhdae!",
            "발 너무 아프겠다..",
            "다음에는 우리 예배당에서 캠프가자!",
            "그래? 친구 많이 사귀겠다!",
            "그래? 친구 많이 사귀겠다!",
            "다음에는 우리 예배당에서 캠프가자!",
            "앵무새 집 근처에서 앵무새를 발견했다.\n 분주하게 움직이고 있다."
        },
        {
            "Oh! Hello!\nNeodo book ilgeuleo wasseo?",
            "고민중이야! 뭐할지..",
            "아니! 라면 먹으러 왔어!",
            "응.. 종교활동 보충 공부 좀 하려고!",
            "응.. 종교활동 보충 공부 좀 하려고!",
            "아니! 라면 먹으러 왔어!",
            "동네 책방에서\n책을 읽는 앵무새를 발견했다."
        },
        {
            "Nan book bomyeonseo\ngyehoeg seuneun jung inde!",
            "오호! 부지런하다!",
            "역시 계획 먼저 세우는 구나~~",
            "우리 예배당으로 오는 건 어때?",
            "역시 계획 먼저 세우는 구나~~",
            "우리 예배당으로 오는 건 어때?",
            "동네 책방에서 책을 읽는 앵무새를 발견했다."
        },
        {
            "Gati chaek ilgdaga gaja!!",
            "미안.. 내가 좀 바빠서..",
            "난 책 읽는 거 싫어.",
            "휴,, 외롭다..",
            "미안.. 내가 좀 바빠서..",
            "난 책 읽는 거 싫어.",
            "동네 책방에서 책을 읽는 앵무새를 발견했다."
        },
        {
            "Kkachiya~~\nnae party e ollae?",
            "언제 하는데? 어디서?",
            "요즘 너무 바쁘다..흑.흑..",
            "고민 좀 해보고~",
            "언제 하는데? 어디서?",
            "고민 좀 해보고~",
            "마트에서 장보고 있는 앵무새를 만났다.\n장바구니에는 파티용품이 가득이다."
        },
        {
            "Naljjaneun Saturday~~\njangsoneun mijeong~~",
            "우리 예배당에서 하는 건 어때?",
            "아직도 못 정했니!! 에휴",
            "드라마 볼 시간이다! 안뇽",
            "우리 예배당에서 하는 건 어때?",
            "아직도 못 정했니!! 에휴",
            "마트에서 장보고 있는 앵무새를 만났다.\n 장바구니에는 파티용품이 가득이다."
        },
        {
            "Party eseo boja!!!\nNeodo chingu lang wa!!",
            "난 친구없어.. 놀리는 거야?",
            "그래! 예배당 새들이랑 갈게!",
            "그날 시간이 안될 거 같아...",
            "그래! 예배당 새들이랑 갈게!",
            "그날 시간이 안될 거 같아...",
            "마트에서 장보고 있는 앵무새를 만났다.\n 장바구니에는 파티용품이 가득이다."
        },
        {
            "Kkachi...\nHello...\nannyeong...",
            " 응 안녕.. 난 갈게",
            "안녕~ 근데 무슨 일 있어?",
            "너 힘이 없어 보인다~",
            "안녕~ 근데 무슨 일 있어?",
            "너 힘이 없어 보인다~",
            "시무룩해 보이는 앵무새를 만났다."
        },
        {
            "yeohaeng jung e camera ga\ngojang I naseo sogsang…sogsang…",
            " 우리 예배당에 오면 새 거 줄게!",
            "A/S 센터에 가봐!",
            "나도 카메라 샀는데!! 히히~",
            "A/S 센터에 가봐!",
            " 우리 예배당에 오면 새 거 줄게!",
            "시무룩해 보이는 앵무새를 만났다."
        },
        {
            "A/S haebogo andoemyeon\nnew camera sayaji..",
            "그냥 핸드폰으로 찍지 그래?",
            "고쳐질 거야! 걱정마!",
            "새 거 사면 나도 보여줘~",
            "고쳐질 거야! 걱정마!",
            "새 거 사면 나도 보여줘~",
            "시무룩해 보이는 앵무새를 만났다."
        },
        {
            "Oh! Kkachi!\nGonghang eneun museun iliya???",
            "햄버거가 너무 먹고 싶어서…",
            "너 보러 왔지!",
            "피곤해 보이네~ 집 가자",
            "너 보러 왔지!",
            "피곤해 보이네~ 집 가자",
            "공항에서 앵무새를 발견했다.\n매우 지친 모습이다."
        },
        {
            "ppalli jib gaseo swillae…\n neomu jollyeo…",
            "예배당으로 가는 건 어때?",
            "그래그래 너희 집으로 가자~",
            "짐은 니가 스스로 들어!",
            "그래그래 너희 집으로 가자~",
            "예배당으로 가는 건 어때?",
            "공항에서 앵무새를 발견했다.\n 매우 지친 모습이다."
        },
        {
            "yeogsi yeohaeng eun\nhimdeulgo jaemisseo! Kkk",
            "다음에는 나랑 가자!",
            "돈 많이 들지 않아?",
            "ㅎㅎ 친구도 많이 사귈 수 있지!",
            "다음에는 나랑 가자!",
            "ㅎㅎ 친구도 많이 사귈 수 있지!",
            "공항에서 앵무새를 발견했다.\n 매우 지친 모습이다."
        },
        {
            "neodo yeonghwa boleo ongeoya??",
            "응! 새로운 영화가 나왔대!",
            "그냥 동네 산책 중인데?",
            "팝콘 하나만 사줘~",
            "응! 새로운 영화가 나왔대!",
            "그냥 동네 산책 중인데?",
            "친구들과 영화를 보러온\n앵무새를 만났다."
        },
        {
            "What movie johahae?\n Nan action joha!",
            "난 콜라가 더 좋아~",
            "드라마를 더 많이 봐.",
            "음.. 뮤지컬영화가 취향이야~",
            "음.. 뮤지컬영화가 취향이야~",
            "드라마를 더 많이 봐.",
            "친구들과 영화를 보러온 앵무새를 만났다."
        },
        {
            "yeonghwa god sijag ine~\nna galge! Daum ebwa!",
            "영화 잘봐~! 후기 알려줘!",
            "운동 좀 해야겠다..",
            "다음에 예배당에서도 영화보자~",
            "영화 잘봐~! 후기 알려줘!",
            "다음에 예배당에서도 영화보자~",
            "친구들과 영화를 보러온 앵무새를 만났다."
        },
        {
            "Oh! Eoseooseyo!\nEo?? Kkachine?",
            "으잉? 여기서 뭐해?",
            "유니폼 잘 어울리네~",
            "어.. 난 쇼핑중인데?",
            "으잉? 여기서 뭐해?",
            "어.. 난 쇼핑중인데?",
            "옷가게에 갔다가\n알바하는 앵무새를 발견했다."
        },
        {
            "Don beollyeogo aleubaiteu jung iya~~",
            "피팅 룸이 어디야?",
            "아하! 하긴 여행을 좋아하니까!",
            "몇 시까지 해?",
            "아하! 하긴 여행을 좋아하니까!",
            "몇 시까지 해?",
            "옷가게에 갔다가 알바하는 앵무새를 발견했다."
        },
        {
            "igeo sale haneunde I os eun eottae??",
            "ㅎㅎㅎ화이팅 나는 갈래~",
            "좋아보인다! 한 번 입어볼래!",
            "이건 내 취향이 아니야..",
            "좋아보인다! 한 번 입어볼래!",
            "이건 내 취향이 아니야..",
            "옷가게에 갔다가 알바하는 앵무새를 발견했다."
        }
    };

    void Start()
    {
        for (int i = 0; i < 45; i++)
        {
            Dictionary<string, string> parrotTemp = new Dictionary<string, string>();
            parrotTemp.Add("question", parrotStr[i, 0]);
            parrotTemp.Add("example1", parrotStr[i, 1]);
            parrotTemp.Add("example2", parrotStr[i, 2]);
            parrotTemp.Add("example3", parrotStr[i, 3]);
            parrotTemp.Add("answer", parrotStr[i, 4]);
            parrotTemp.Add("soso", parrotStr[i, 5]);
            parrotTemp.Add("meeting", parrotStr[i, 6]);
            parrotDic[i] = parrotTemp;
        }
    }
}