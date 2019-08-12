using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapReceiver : MonoBehaviour
{
    public GameObject[] mapList = new GameObject [6];
    // 잔디공원, 바름배움촌, 회색도심, 야자바다, 정글숲, 북극설원 
    // 총 6가지 맵 존재
    public static GameObject[] mapInput = new GameObject [4];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++){
            mapInput[i] = mapList[MapChecker.mapOutput[i]];
            if(!mapInput[i].activeSelf) mapInput[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
