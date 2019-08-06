using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{

    public int itemType;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(lifeManager.lifeNum == 0) Destroy(gameObject);
        else{
        transform.Translate(-1*speed*Time.deltaTime,0,0);

        if(transform.position.x < -4f) Destroy(gameObject);
        if(transform.position.y < -4f) Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
            if(itemType == 0) scoreManager.beanScore += 1;
            if(itemType == 1) scoreManager.diceScore += 1;
            if(itemType == 2) lifeManager.lifeNum += 1;
            
            Destroy(gameObject);
    }
}
