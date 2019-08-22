using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{

    public static bool tutorial;

    public GameObject panel, touchX, player;
    public GameObject[] page = new GameObject [4];

    // Start is called before the first frame update
    void Start()
    {
        if(tutorial){
            player.SetActive(false);
            touchX.SetActive(true);
            panel.SetActive(true);
        }
    }

    public void p1Click(){
        page[0].SetActive(false);
        page[1].SetActive(true);
    }

    public void p2Click(){
        page[1].SetActive(false);
        page[2].SetActive(true);
    }
    public void p3Click(){
        page[2].SetActive(false);
        page[3].SetActive(true);
    }

    public void p4Click(){
        touchX.SetActive(false);
        panel.SetActive(false);
        player.SetActive(true);
        tutorial = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
