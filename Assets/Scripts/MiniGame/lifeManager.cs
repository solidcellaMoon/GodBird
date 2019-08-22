using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeManager : MonoBehaviour
{
    public static int lifeNum;

    void Start(){
        lifeNum = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeNum > 6) lifeNum = 6;
        if(lifeNum < 0) lifeNum = 0;
        // 한 판에 400 이상은 못 얻는다.
        if(scoreManager.beanScore > 399) lifeNum = 0;
    }
}
