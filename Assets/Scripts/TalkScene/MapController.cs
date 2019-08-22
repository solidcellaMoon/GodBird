using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject Canvas, DialManager, defCanvas, npcPos, motion;
    public GameObject[] player = new GameObject[2]; // 0: 날기, 1: 앉기
    Vector3 initPos = new Vector3 (-1, 2.09f, -1);
    float speed = 3f;
    public Text placeTxt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NowMoving());
        NpcPosition();
    }

    IEnumerator NowMoving(){
        while(!MapManager.check){
            if(MapManager.check) break;
            placeTxt.text = "이동 중";
            yield return new WaitForSeconds(0.2f);
            for(int i = 0; i < 3; i++){
            placeTxt.text += ".";
            yield return new WaitForSeconds(0.2f);
            }
        }
    }

    void NpcPosition(){
        switch(MapManager.birdType){
            case 0: case 1: case 2: 
            npcPos.transform.position = new Vector3 (14.87f,1.94f,0); break;
            case 3: case 4:
            npcPos.transform.position = new Vector3 (14.87f,2,0); break;
            case 5:
            npcPos.transform.position = new Vector3 (14.87f,1.87f,0); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(MapManager.check) placeTxt.text = "";

        if(MapManager.check) player[0].transform.Translate(2 * Time.deltaTime, 0, 0);
        if(player[0].transform.position.x < initPos.x && !MapManager.check){
            player[0].transform.Translate(Time.deltaTime, 0, 0);
        }

        npcPos.GetComponent<Animator>().runtimeAnimatorController = 
        Resources.Load<RuntimeAnimatorController>("anime/bird_"+MapManager.birdType.ToString())
        as RuntimeAnimatorController;

        npcPos.transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        if(!DialManager.activeSelf){
            speed = 3;
            player[0].SetActive(true);
            player[1].SetActive(false);
            defCanvas.SetActive(true);
            //StartCoroutine(NowMoving());
        } else {
            speed = 0;
            player[0].SetActive(false);
            player[1].SetActive(true);
            motion.transform.position = 
                npcPos.transform.position + new Vector3 (0,1.2f,0);
        }
        if(!DialogManager.talkStart){
            Canvas.SetActive(false);
            DialManager.SetActive(false);
            motion.SetActive(false);
        }

    }

    void OnTriggerEnter2D(Collider2D collision){
        MapManager.speed = 0;
        defCanvas.SetActive(false);
        Canvas.SetActive(true);
        DialManager.SetActive(true);
    }

}
