﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cloudController : MonoBehaviour
{   
    public float speed;
    void Update()
    {
        // 게임 오버시 삭제
        if(lifeManager.lifeNum == 0 && 
        SceneManager.GetActiveScene().name == "MiniGame") Destroy(gameObject);
        else{
            transform.Translate(-1*speed*Time.deltaTime,0,0);
            
            // 범위 이탈시 삭제
            if(transform.position.x < -6.5f)
            Destroy(gameObject);
        }

    }

}
