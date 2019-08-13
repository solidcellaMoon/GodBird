using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudGenerator : MonoBehaviour
{
    public GameObject[] prefab = new GameObject [4];
    GameObject cloud;
    float span = 1.0f, delta = 0, px, py;

    void Update()
    {
        this.delta += 2*Time.deltaTime;

         if(this.delta > this.span){
            this.delta = 0;
            px = 8; py = Random.Range(-4.5f,5.5f);
            SelectType();
            cloud.transform.position = new Vector3(px,py,1);
        }
        
    }

    void SelectType(){
        int type = Random.Range(0,4);
        switch(type){
            case 0:
            cloud = Instantiate(prefab[0]) as GameObject;
            break;
            case 1:
            cloud = Instantiate(prefab[1]) as GameObject;
            break;
            case 2:
            cloud = Instantiate(prefab[2]) as GameObject;
            break;
            default:
            cloud = Instantiate(prefab[3]) as GameObject;
            break;
        }
    }
}
