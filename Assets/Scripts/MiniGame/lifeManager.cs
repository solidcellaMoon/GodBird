using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeManager : MonoBehaviour
{
    public static int lifeNum = 3;
    public static int limit = 399;

    void Start(){

        // 지우면 절대 안됨 !!!!!!!!!!!
        lifeNum = gameManager.gameLifeNum;
        limit = gameManager.gameLimit;

    }

    // Update is called once per frame
    void Update()
    {
        if(lifeNum > 6) lifeNum = 6;
        if(lifeNum < 0) lifeNum = 0;
        // 한 판에 콩 limit개 이상은 못 얻는다.
        if(scoreManager.beanScore > limit) lifeNum = 0;
    }
}
