using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager : MonoBehaviour
{
    GameObject player;
    PlayerMove playerScript;
    dashAttack dashScript;
    public float speed;

    public void Start(){
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMove> ();
        dashScript = player.GetComponent<dashAttack> ();
    }
    public void UpPressed(){
        playerScript.inputUp = true;
    }

    public void UpOff(){
        playerScript.inputUp = false;
    }

    public void DownPressed(){
        playerScript.inputDown = true;
    }

    public void DownOff(){
        playerScript.inputDown = false;
    }

    public void DashPressed(){
        dashScript.inputDashDwn = true;
        //dashScript.inputDash = true;
    }

    public void DashOff(){
        dashScript.inputDashUp = true;
    }

}
