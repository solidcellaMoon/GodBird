using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supervisor : MonoBehaviour
{
    public GameObject Canvas, DialManager;

    int index;
    int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(waitTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(!DialogManager.talkStart){
            Canvas.SetActive(false);
            DialManager.SetActive(false);
        }
    }

    IEnumerator waitTime(){
        while(true){
            cnt++;
            if(cnt == 6) {
            Canvas.SetActive(true);
            DialManager.SetActive(true);
            }
            if(cnt == 16) cnt = 0;
            yield return new WaitForSeconds(1f);
        }
    }
}
