using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashAttack : MonoBehaviour
{
    public bool inputDashDwn = false;
    public bool inputDashUp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputDashDwn){
            PlayerMove.superTime = true;
            //Debug.Log("슈퍼타임 시작");
            transform.Translate(0.9f,0,0);
            StartCoroutine(waitTime(0.2f));
            inputDashDwn = false;
        }
        if(inputDashUp){
            PlayerMove.unBeatTime = true;
            transform.Translate(-0.9f,0,0); 
            StartCoroutine(waitTime(0.1f));
            inputDashUp = false;
        }

    }

    IEnumerator waitTime(float time){
        //Debug.Log("기다리는중");
        yield return new WaitForSeconds(time);
        if(PlayerMove.superTime == true && PlayerMove.unBeatTime == false) {
            PlayerMove.superTime = false;
           // Debug.Log("슈퍼타임 해제"); 
            }
        if(!Input.GetKey(KeyCode.Space) && PlayerMove.unBeatTime == true){
            PlayerMove.unBeatTime = false;
        }
    }
}
