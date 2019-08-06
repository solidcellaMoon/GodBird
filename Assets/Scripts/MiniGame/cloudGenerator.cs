using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudGenerator : MonoBehaviour
{

    public GameObject 
    cloudPrefab,cloud2Prefab,
    cloud3Prefab,cloud4Prefab;
    GameObject cloud;
    float span = 1.0f, delta = 0, time, px, py;

    void Update()
    {
         if(lifeManager.lifeNum == 0){
             this.delta = 0; }
        else {
        this.delta += 2*Time.deltaTime;
         if(this.delta > this.span){
            this.delta = 0;
            px = 8;
            py = Random.Range(-4.5f,5.5f); // 기본은 -3.8, 4.5
            SelectType();
            cloud.transform.position = new Vector3(px,py,1);
        }
    }
        
    }

    void SelectType(){
        int type = Random.Range(0,4);
        switch(type){
            case 0:
            cloud = Instantiate(cloudPrefab) as GameObject;
            break;
            case 1:
            cloud = Instantiate(cloud2Prefab) as GameObject;
            break;
            case 2:
            cloud = Instantiate(cloud3Prefab) as GameObject;
            break;
            default:
            cloud = Instantiate(cloud4Prefab) as GameObject;
            break;
        }
    }
}
