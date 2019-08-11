using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startScirpt : MonoBehaviour
{
    public GameObject startUI;
    public GameObject Manager, Player, Generator;
    Vector3 initPos = new Vector3 (-2.62f,0,0);
    float moveSpeed = 6f;
    public Text uiText;
    int countTime = 4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(Player.activeSelf){
            Player.transform.Translate(moveSpeed*Time.deltaTime,0,0);
            moveSpeed *= 0.95f;
            if(Player.transform.position.x > initPos.x)
            Player.transform.position = initPos; 
        }

        if(countTime < -1) {
            Player.GetComponent<PlayerMove>().enabled = true;
            Player.GetComponent<dashAttack>().enabled = true;
            Destroy(startUI);
        }
         
    }

     IEnumerator CountDown(){

        while(true){
            if(countTime == 4) uiText.text = "READY";
            else if(countTime > 0) uiText.text = countTime.ToString();
            else uiText.text = "START";
            if(countTime == 3){
                Manager.SetActive(true);
                Player.SetActive(true);
                Generator.SetActive(true);
            }
            countTime--;
            yield return new WaitForSeconds(1f);
        }

    }
}
