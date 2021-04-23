﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chick : MonoBehaviour
{
    public Dictionary<string, string>[] chickDic = new Dictionary<string, string>[46];

    public string[,] chickStr = new string[45, 7]
    {
        {
            "안녕하세요!\n우리 동네에서 처음 뵈는 분이네요!\n이사 오셨어요?",
            " 후후, 이 별에서 6억 광년 떨어진\n행성으로부터 온 까치야.",
            "난 까치야.\n네 자기소개 먼저 해주지 그래?",
            "눈썰미가 좋네! 잠깐 다른 데 살았다가\n얼마 전 컴백한 까치라고 해.",
            " 후후, 이 별에서 6억 광년 떨어진\n행성으로부터 온 까치야.",
            "눈썰미가 좋네! 잠깐 다른 데 살았다가\n얼마 전 컴백한 까치라고 해.",
            "공원에서 병아리를 만났다.\n병아리는 인기스타 오목눈이를\n좋아하는 중학생이다."
        },
        {
            "앞으로 자주 보겠네요~\n저는 요 앞에 조류중학교 다녀요.\n까치씨는요?",
            "하하. 어른이 하는 일을\n벌써부터 궁금해 하면 안된단다.",
            "나도 그 중학교 졸업했는데!\n우린 인연인가봐~",
            "난 전지전능한 신의 말씀을\n세상에 전하고 있지.",
            "나도 그 중학교 졸업했는데!\n우린 인연인가봐~",
            "하하. 어른이 하는 일을\n벌써부터 궁금해 하면 안된단다.",
            "공원에서 병아리를 만났다.\n병아리는 인기스타 오목눈이를 좋아하는 중학생이다."
        },
        {
            "아~ 정말 학교가기 너무 귀찮아요.\n방에 누워서 새스타나 하고 싶다.",
            "공부하기 싫으면\n성직자가 되는 것도 나쁘지 않아! ",
            "학교 끝나고 하면 되지 뭐!\n공부 열심히 해~!",
            "나 때는 공부아님 할 거 없었는데\n너는 복받은거야 임마. ",
            "학교 끝나고 하면 되지 뭐!\n공부 열심히 해~!",
            "공부하기 싫으면\n성직자가 되는 것도 나쁘지 않아! ",
            "공원에서 병아리를 만났다.\n병아리는 인기스타 오목눈이를 좋아하는 중학생이다."
        },
        {
            "어랏, 까치씨다!\n여기서 뭐하세요?",
            "너는 학교에 있을 시간 아닌가?\n왜 여기 있어?",
            "우리 예배당에 필요한 물건을\n구매하러 가는 중이야. ",
            "열심히 숨쉬러 다니고 있지. 너는 뭐해?",
            "열심히 숨쉬러 다니고 있지. 너는 뭐해?",
            "우리 예배당에 필요한 물건을\n구매하러 가는 중이야. ",
            "학교 근처에서 병아리를 만났다.\n가벼운 발걸음으로\n 걸어가는 모습을 발견했다."
        },
        {
            "저는 덕질하러 가야 돼서 바빠요.\n부모님껜 비밀이에요!",
            "오목눈이를 위해서라면 어쩔 수 없지.",
            "혹시 요즘 핫한 오목눈이?",
            "덕질이라면 오목눈이 팬인가?",
            "혹시 요즘 핫한 오목눈이?",
            "덕질이라면 오목눈이 팬인가?",
            "학교 근처에서 병아리를 만났다.\n가벼운 발걸음으로 걸어가는 모습을 발견했다."
        },
        {
            "우와!\n제가 오목눈이 좋아하는거\n어떻게 아셨어요?",
            "왠지 그럴 것 같았어~\n나도 오목눈이 좋아하거든.",
            "너가 뭘 좋아하는지 미리 조사해놨지~",
            "요즘 오목눈이가 제일 핫하잖아!",
            "왠지 그럴 것 같았어~\n나도 오목눈이 좋아하거든.",
            "요즘 오목눈이가 제일 핫하잖아!",
            "학교 근처에서 병아리를 만났다.\n가벼운 발걸음으로 걸어가는 모습을 발견했다."
        },
        {
            "까치씨 마침 잘 만났네요!\n저 좀 도와주세요오",
            "무거워보이는데 좀 들어줄까?",
            "뭘 도와주면 돼?",
            "내가 또 한 근육 하지.",
            "내가 또 한 근육 하지.",
            "무거워보이는데 좀 들어줄까?",
            "가게에서 병아리를 만났다.\n양 날개에 음료수를 가득 들고 있다."
        },
        {
            "이번에 우리 목눈이가 찍은\nCF 못 보셨어욧?!",
            "쿌라 CF?",
            "샤이다 CF?",
            "뽠타 CF?",
            "쿌라 CF?",
            "샤이다 CF?",
            "가게에서 병아리를 만났다.\n양 날개에 음료수를 가득 들고 있다."
        },
        {
            "포스터가 진짜 대박이에요ㅠㅠ\n한 달 동안 쿌라만 먹을 거예요.",
            "그냥 포스터만 따로 구매하는 게 더 빠르겠다.",
            "나도 쿌라 좋아하는데 같이 먹자ㅎㅎ",
            "쿌라만 먹으면 질리니까\n꼭 멘토스도 같이 먹어!",
            "쿌라만 먹으면 질리니까 꼭 멘토스도 같이 먹어!",
            "나도 쿌라 좋아하는데 같이 먹자ㅎㅎ",
            "가게에서 병아리를 만났다.\n양 날개에 음료수를 가득 들고 있다."
        },
        {
            "(까치를 발견하지 못하고)\n에휴…",
            "무슨 일 있어? 오목눈이가 은퇴한대?",
            "무슨 일 있어? 부모님이랑 싸웠어?",
            "요즘 고민이 있지 않으십니까.",
            "무슨 일 있어? 부모님이랑 싸웠어?",
            "무슨 일 있어? 오목눈이가 은퇴한대?",
            "공원에서 병아리를 만났다.\n웬일로 가만히 벤치에 앉아 있다."
        },
        {
            "어, 까치씨네… 어떻게 아셨어요?\n부모님이 쓸데없는 데다\n돈쓰지 말라고 용돈도 끊었어요ㅠㅠ",
            "헉. 얼마 뒤에 콘서트 있지 않아?",
            "한창 덕질 할 나이인데 부모님이 너무하셨네...",
            "그러게 부모님 걱정하시게 왜 돈을 막 썼어~",
            "헉. 얼마 뒤에 콘서트 있지 않아?",
            "그러게 부모님 걱정하시게 왜 돈을 막 썼어~",
            "공원에서 병아리를 만났다.\n웬일로 가만히 벤치에 앉아 있다."
        },
        {
            "콘서트 갈 돈 모으려면 큰일이에요...\n요즘 알바도 구하기 힘들어서…",
            "만약 도움 필요하면 얘기해!\n내가 일하는 곳 알바자리 추천해줄게.",
            "잘됐다! 우리 예배당이\n일손이 부족해서 고민이었는데.",
            "우리도 신께 기도드리면\n모든 걱정을 덜 수 있을 거야!",
            "만약 도움 필요하면 얘기해!\n내가 일하는 곳 알바자리 추천해줄게.",
            "잘됐다! 우리 예배당이\n일손이 부족해서 고민이었는데.",
            "공원에서 병아리를 만났다.\n웬일로 가만히 벤치에 앉아 있다."
        },
        {
            "까치씨!!!\n오늘 티저 떴어요ㅠㅠ\n병아리 쓰러져~~",
            "무슨 티저? 이번에 컴백한대?",
            "킹갓제너럴 오목눈이 완전 쩔던데.",
            "호오 벌써? 소속사 열일하네!",
            "킹갓제너럴 오목눈이 완전 쩔던데.",
            "호오 벌써? 소속사 열일하네!",
            "길에서 병아리를 만났다.\n신나서 이쪽으로 달려오고 있다."
        },
        {
            "도와주신 덕분에 티켓값도\n금방 모았어요. 감사해요ㅜㅠ",
            "뭘~ 이게 다 미래를 위한\n건설적인 투자인 셈이지.",
            "나도 덕분에 편하게 일하고 좋았어.",
            "뭘~ 오목눈이 팬이라는데 도와야지!",
            "뭘~ 오목눈이 팬이라는데 도와야지!",
            "나도 덕분에 편하게 일하고 좋았어.",
            "길에서 병아리를 만났다.\n신나서 이쪽으로 달려오고 있다."
        },
        {
            "이제 부모님 허락 받고\n티켓팅만 잘하면 돼요!!",
            "부모님 걱정 안하시게 꼭 허락 받고~\n티켓팅도 파이팅!",
            "우리 예배당 와서 기도 하고 가면\n100퍼 성공할 거야!",
            "나도 너 티켓팅 성공할 수 있도록 기도해줄게ㅎㅎ",
            "부모님 걱정 안하시게 꼭 허락 받고~\n티켓팅도 파이팅!",
            "나도 너 티켓팅 성공할 수 있도록 기도해줄게ㅎㅎ",
            "길에서 병아리를 만났다.\n신나서 이쪽으로 달려오고 있다."
        },
        {
            "(까치를 발견하고)\n안녕하세요 까치씨...",
            "집에 가는 길이야?",
            "안녕! 기분 좋아보이네!",
            "무슨 일 있어? 얼굴빛이 안 좋네.",
            "무슨 일 있어? 얼굴빛이 안 좋네.",
            "집에 가는 길이야?",
            "학교 근처에서 하교하는 병아리를 만났다.\n기운이 없어 보인다."
        },
        {
            "흑... 우리 목눈이 티켓팅\n광탈했어요 ㅠㅠㅠ",
            "아이구ㅠㅠ 자 여기\n오목눈이 뉴짤보면서 맘을 달래렴.",
            "저런...다음에 또 기회가 있을거야..!",
            "이게 다 오목눈이가 인기스타라는 증거지!",
            "아이구ㅠㅠ 자 여기\n오목눈이 뉴짤보면서 맘을 달래렴.",
            "저런...다음에 또 기회가 있을거야..!",
            "학교 근처에서 하교하는 병아리를 만났다.\n기운이 없어 보인다."
        },
        {
            "훌쩍...\n나도 목눈이를 눈앞에서\n보고싶었는데ㅔㅔ!!!",
            "취소표라도 구할 수 있기를 기도할게.",
            "우리 예배당에서 표 남는 조류가\n있는지 한 번 알아봐줄게.",
            "다음에는 우리 예배당 컴퓨터로 할래?\n그 분이 가호를 내려주실거야.",
            "우리 예배당에서 표 남는 조류가\n있는지 한 번 알아봐줄게.",
            "취소표라도 구할 수 있기를 기도할게.",
            "학교 근처에서 하교하는 병아리를 만났다.\n기운이 없어 보인다."
        },
        {
            "(친구들과 수다중)\n대박 말도 안 돼\n오목눈이 맞지? 그렇지?",
            "오목눈이 아니야.",
            "오목눈이 새소식이라도 떴어?",
            "오목눈이를 만났어?",
            "오목눈이를 만났어?",
            "오목눈이 새소식이라도 떴어?",
            "공원에서 병아리와 친구들을 만났다.\n매우 흥분해있는 것 같다."
        },
        {
            "그게 있잖아요~!~!\n오목눈이가 제 새스타 글에\n하트 눌러줬어요~~!!",
            "헉 병아리 완전 성덕이네!!",
            "네 열정을 그 분이 아신거야!",
            "와 축하해! 어서 캡쳐해서 간직해!",
            "헉 병아리 완전 성덕이네!!",
            "와 축하해! 어서 캡쳐해서 간직해!",
            "공원에서 병아리와 친구들을 만났다.\n매우 흥분해있는 것 같다."
        },
        {
            "오늘을 '오목눈이 영접일'로\n달력에 적어두고\n매년 기억할 거예요 ㅠㅠ",
            "내일이 우리의 그 분이 오신 날이야.\n내일도 매년 기억해줘!",
            "충분히 그럴만한 가치가 있는 날이다.\n 진짜 축하해!!",
            "나도 선물 챙겨줄게.",
            "충분히 그럴만한 가치가 있는 날이다.\n 진짜 축하해!!",
            "나도 선물 챙겨줄게.",
            "공원에서 병아리와 친구들을 만났다.\n매우 흥분해있는 것 같다."
        },
        {
            "앗 까치씨!\n이번에 오목눈이랑 꿩이랑\n열애설 난 것 보셨어요?",
            "오목눈이가 아깝네.",
            "앗 나도 꿩 좋아해!",
            "그래서 이렇게\n매운 음식을 잔뜩 사는거야?",
            "그래서 이렇게\n매운 음식을 잔뜩 사는거야?",
            "오목눈이가 아깝네.",
            "편의점에서 병아리를 만났다.\n매운 음식을 잔뜩 들고있다."
        },
        {
            "사실 저는 둘이 사귀는 건 상관없어요.\n제가 화가 나는건...",
            "소속사?",
            "꿩 팬들?",
            "기자들?",
            "꿩 팬들?",
            "기자들?",
            "편의점에서 병아리를 만났다.\n매운 음식을 잔뜩 들고있다."
        },
        {
            "꿩 팬덤이 목눈이를 욕하더라구요!\n어휴 전 빨리 매운거 먹고\n스트레스를 풀어야겠어요!!",
            "그렇다고 같이 싸우면 안 되지.",
            "아이스크림이나 음료수도 꼭 같이 먹어줘야해!",
            "매운 음식 너무 많이 먹지 않게 조심해!",
            "매운 음식 너무 많이 먹지 않게 조심해!",
            "아이스크림이나 음료수도 꼭 같이 먹어줘야해!",
            "편의점에서 병아리를 만났다.\n매운 음식을 잔뜩 들고있다."
        },
        {
            "까치씨!\n까치씨의 도움이 필요해요!",
            "기분이 되게 좋아보이는구나!",
            "도와주면 우리 예배당에 나올래?",
            "뭘 도와주면 되는데?",
            "뭘 도와주면 되는데?",
            "기분이 되게 좋아보이는구나!",
            "거리를 걷다가 병아리를 만났다.\n반가워하며 이쪽으로 온다."
        },
        {
            "지금 목눈이가 음악방송에 나와서\n순위 투표중이거든요!\n까치씨도 한 표 부탁드려요!",
            "이미 했지! 나도 오목눈이의 팬이라니까~",
            "오목눈이를 위해서라면 얼마든지! 어떻게 하는데?",
            "한 표만으로 되겠어? 표 수 조작도 해줄게.",
            "오목눈이를 위해서라면 얼마든지! 어떻게 하는데?",
            "이미 했지! 나도 오목눈이의 팬이라니까~",
            "거리를 걷다가 병아리를 만났다.\n반가워하며 이쪽으로 온다."
        },
        {
            "와 감사해요!\n우리 같이 목눈이가 1등하기를 바라요!",
            "우리 같이 예배당에 가서 기도드릴래?",
            "오목눈이는 무조건 1등할거야!",
            "나도 내가 믿는 신께 기도드릴게!",
            "나도 내가 믿는 신께 기도드릴게!",
            "오목눈이는 무조건 1등할거야!",
            "거리를 걷다가 병아리를 만났다.\n반가워하며 이쪽으로 온다."
        },
        {
            "까치씨!\n도서관에서 뵙는건 처음이네요!",
            "지나가는 길이었어.",
            "책 빌리고 오는 길이야?",
            "그 분의 말씀을 널리 전하려고.",
            "책 빌리고 오는 길이야?",
            "지나가는 길이었어.",
            "도서관 앞에서 병아리를 만났다.\n의상 관련 책을 들고있다."
        },
        {
            "전 의상 관련 책을 빌렸어요.\n의상 디자인을 공부해보려고요!",
            "패션 코디네이터! 응원할게!",
            "학교 공부부터 열심히 해야지.",
            "멋진 꿈이야! 그런데 갑자기 왜?",
            "멋진 꿈이야! 그런데 갑자기 왜?",
            "패션 코디네이터! 응원할게!",
            "도서관 앞에서 병아리를 만났다.\n의상 관련 책을 들고있다."
        },
        {
            "오목눈이 코디가...\n목눈이의 귀여움을 너무 못 살려서요...\n제가 목눈이의 코디로 취직할거예요!",
            "우리 예배당에 의상 디자이너분이 있는데 만나볼래?",
            "정말 공감해. 꼭 코디가 되서\n오목눈이를 그 이상한 패션에서 해방시켜줘!",
            "생각보다 준비해야할 게 많을거야.\n그래도 화이팅!",
            "생각보다 준비해야할 게 많을거야.\n그래도 화이팅!",
            "우리 예배당에 의상 디자이너분이 있는데 만나볼래?",
            "도서관 앞에서 병아리를 만났다.\n의상 관련 책을 들고있다."
        },
        {
            "후우우...\n덕질은 정말 힘든 것이군요, 까치씨...",
            "인생은 원래 그런거지.",
            "어덕행덕!\n어차피 덕질을 할거면 행복하게 하렴!",
            "오목눈이에게 무슨 일이 생겼어?",
            "오목눈이에게 무슨 일이 생겼어?",
            "인생은 원래 그런거지.",
            "병아리가 한숨을 쉬며 걸어가고 있다.\n땅이 꺼질 것 같다."
        },
        {
            "오목눈이 팬싸인회 티켓을 얻으려면\n굿즈를 사야하는데\n너무 비싸서 고민이에요.",
            "비싸도 직접 오목눈이를\n만날 수 있는 기회인걸!",
            "아르바이트 시간을 늘리는 건 어때?",
            "부담되는 가격이면 어쩔 수 없지...\n다음 기회를 노려보는 게 어때?",
            "비싸도 직접 오목눈이를\n만날 수 있는 기회인걸!",
            "아르바이트 시간을 늘리는 건 어때?",
            "병아리가 한숨을 쉬며 걸어가고 있다.\n땅이 꺼질 것 같다."
        },
        {
            "심지어 팬싸 티켓도\n랜덤으로 추첨하는거래요.\n정말 쉽지 않아요...",
            "너는 운이 좋은 편이니까\n굿즈 사면 무조건 당첨될거야!",
            "비싼데 확정도 아니라니...\n합리적인 소비는 아닌거같아.",
            "그 분이 함께하실거야! 행운을 빌어!",
            "그 분이 함께하실거야! 행운을 빌어!",
            "비싼데 확정도 아니라니...\n합리적인 소비는 아닌거같아.",
            "병아리가 한숨을 쉬며 걸어가고 있다.\n땅이 꺼질 것 같다."
        },
        {
            "까치씨! 까치씨! 대박사건!!\n저 팬싸인회 당첨됐어요!!",
            "대박대박! 세상에! 축하해!!",
            "대박사건!! 드디어 오목눈이를\n눈앞에서 볼 수 있겠구나!",
            "대박사건! 하늘이 도운거야!",
            "대박사건!! 드디어 오목눈이를\n눈앞에서 볼 수 있겠구나!",
            "대박사건! 하늘이 도운거야!",
            "거리를 걷고 있는데\n병아리가 뛰어온다."
        },
        {
            "까치씨가 기도해주신 덕분일거예요!\n꿈에서 어떤 목소리가 들렸거든요!",
            "드디어 그 분이\n너에게로 오셨구나!",
            "인자하신 그 분은 꿈에서\n축복을 내리시지. 정말 축하해!",
            "아냐 네가 운이 좋았던 거야.",
            "인자하신 그 분은 꿈에서\n축복을 내리시지. 정말 축하해!",
            "드디어 그 분이\n너에게로 오셨구나!",
            "거리를 걷고 있는데 병아리가 뛰어온다."
        },
        {
            "그 분이 진짜 존재할지도\n모른다고 생각했어요.\n진짜 신기한 경험이었어요!",
            "그 분은 실재해.\n내 꿈에도 자주 축복을 내려주시거든!",
            "너도 선택받은거야!\n그 분을 더 뵙고 싶으면 우리 예배당에 오렴.",
            "우리 신자가 되면\n신기한 경험을 더 자주 할 수 있어!",
            "너도 선택받은거야!\n그 분을 더 뵙고 싶으면 우리 예배당에 오렴.",
            "그 분은 실재해.\n내 꿈에도 자주 축복을 내려주시거든!",
            "거리를 걷고 있는데 병아리가 뛰어온다."
        },
        {
            "어휴... 힘들어.\n평생 모아둔 체력을 다 쓴 기분이예요.\n그래도 우리 목눈이는 짱이었어요...",
            "오목눈이가 우리 동네에 왔었어?",
            "팬싸인회 다녀왔구나?",
            "콘서트! 다녀왔구나!",
            "콘서트! 다녀왔구나!",
            "오목눈이가 우리 동네에 왔었어?",
            "버스에서 내리는 병아리를 만났다.\n지쳐보인다."
        },
        {
            "제가 드디어 오목눈이 콘서트에 다녀왔거든요!!\n이리저리 밀려서 좀 힘들었어요.",
            "그래도 보람찼겠는걸?",
            "내일 휴일이니까 푹 쉬어.",
            "나도 전에 콘서트 갔다가\n납작해져서 돌아왔잖아.",
            "그래도 보람찼겠는걸?",
            "내일 휴일이니까 푹 쉬어.",
            "버스에서 내리는 병아리를 만났다.\n지쳐보인다."
        },
        {
            "빨리 돌아가서 오목눈이 영접 사실을\n새스타에도 올려야겠어요!",
            "그런건 콘서트 갈 때, 시작 전,\n끝나고 시시 각각 올려야지!",
            "그 분이 말씀하시길,\n좋은 건 나눌수록 커진다고 그랬어~",
            "그래 빨리 써야 생생하게 기록할 수 있지!",
            "그 분이 말씀하시길,\n좋은 건 나눌수록 커진다고 그랬어~",
            "그런건 콘서트 갈 때, 시작 전,\n끝나고 시시 각각 올려야지!",
            "버스에서 내리는 병아리를 만났다.\n지쳐보인다."
        },
        {
            "흠흠흠~~\n까치씨 오랜만이에요~",
            "음악 듣고 있는거야?",
            "무슨 음악 들어?",
            "오렌지를 먹은지 얼마나 오랜지~",
            "무슨 음악 들어?",
            "음악 듣고 있는거야?",
            "공원에서 병아리를 만났다.\n이어폰으로 음악을 듣고 있다."
        },
        {
            "이번에 오목눈이랑 꾀고리랑\n듀엣곡을 냈거든요!",
            "꾀고리가 누구야? 처음 듣는데.",
            "그 천상의 음색 꾀꼬리?",
            "음악계 최고끼리의 듀엣이네!\n기획한 사람 아주 칭찬해~",
            "음악계 최고끼리의 듀엣이네!\n기획한 사람 아주 칭찬해~",
            "그 천상의 음색 꾀꼬리?",
            "공원에서 병아리를 만났다.\n이어폰으로 음악을 듣고 있다."
        },
        {
            "저 꾀꼬리도 엄청 좋아하거든요~\n이번 듀엣 너무 좋아요~",
            "우리 취향이 잘 통하네~ 나도 꾀꼬리 완전 팬이거든!",
            "예배당에서 쓸 홍보곡이 필요했는데, 나도 들어봐야겠다!",
            "노래 잘 부르는 새를 좋아하는구나?",
            "우리 취향이 잘 통하네~ 나도 꾀꼬리 완전 팬이거든!",
            "예배당에서 쓸 홍보곡이 필요했는데, 나도 들어봐야겠다!",
            "공원에서 병아리를 만났다.\n이어폰으로 음악을 듣고 있다."
        },
        {
            "(까치를 보지 못하고)\n아무것도 모르면서!!",
            "무슨일이야?",
            "친구들이랑 싸웠어?",
            "부모님과 싸웠어?",
            "부모님과 싸웠어?",
            "친구들이랑 싸웠어?",
            "병아리가 전화를 거칠게 끊고 걸어간다.\n화가 나 보인다."
        },
        {
            "부모님이 어차피 오목눈이는 날 모른다고,\n좀 생산적인 일을 하래요.",
            "부모님이 말씀이 심하셨네.",
            "부모님과 진지하게\n대화해볼 필요가 있을 것 같아.",
            "그렇지 않아.\n오목눈이가 네 새스타에 하트도 눌러줬잖아!",
            "부모님과 진지하게\n대화해볼 필요가 있을 것 같아.",
            "그렇지 않아.\n오목눈이가 네 새스타에 하트도 눌러줬잖아!",
            "병아리가 전화를 거칠게 끊고 걸어간다.\n화가 나 보인다."
        },
        {
            "부모님은 제 덕질을\n유치한 것으로 생각하시는 것 같아요.\n어떻게 해야할까요?",
            "다음에 부모님과 우리 예배당에 와봐.\n이야기하는 걸 도와줄게.",
            "네가 느끼는 취미의 중요성을\n설명하면 이해해주실거야.",
            "할 일을 잘 하면서 덕질도 하면\n부모님도 허락하시지 않을까?",
            "다음에 부모님과 우리 예배당에 와봐.\n이야기하는 걸 도와줄게.",
            "네가 느끼는 취미의 중요성을\n설명하면 이해해주실거야.",
            "병아리가 전화를 거칠게 끊고 걸어간다.\n화가 나 보인다."
        }
    };


    void Start()
    {
        for (int i = 0; i < 45; i++)
        {
            Dictionary<string, string> chickTemp = new Dictionary<string, string>();
            chickTemp.Add("question", chickStr[i, 0]);
            chickTemp.Add("example1", chickStr[i, 1]);
            chickTemp.Add("example2", chickStr[i, 2]);
            chickTemp.Add("example3", chickStr[i, 3]);
            chickTemp.Add("answer", chickStr[i, 4]);
            chickTemp.Add("soso", chickStr[i, 5]);
            chickTemp.Add("meeting", chickStr[i, 6]);
            chickDic[i] = chickTemp;
        }
    }
}
