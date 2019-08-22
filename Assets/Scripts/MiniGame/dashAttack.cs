using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashAttack : MonoBehaviour
{
    public bool inputDashDwn = false;
    public bool inputDashUp = false;

    public AudioSource dashBgm;

    // Update is called once per frame
    void Update()
    {
        if(inputDashDwn || Input.GetKeyDown("space")){
            PlayerMove.superTime = true;
            transform.Translate(0.9f,0,0);
            dashBgm.Play();
            StartCoroutine(waitTime(0.2f));
            inputDashDwn = false;
        }
        if(inputDashUp || Input.GetKeyUp("space")){
            transform.Translate(-0.9f,0,0); 
            PlayerMove.superTime = false;
            inputDashUp = false;
        }

    }

    IEnumerator waitTime(float time){

        yield return new WaitForSeconds(time);

        if(PlayerMove.superTime && !PlayerMove.unBeatTime) 
            PlayerMove.superTime = false;
        
    }

}
