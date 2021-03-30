using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textPrint : MonoBehaviour
{
    public string text;
    public GameObject nextButton;
    public AudioSource talkBgm;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(false);
        gameObject.GetComponent<Text>().text = "";
        if(text != "") StartCoroutine(printTxt(text));
    }

    IEnumerator printTxt(string str){
        int i = 0;
        char[] arr = str.ToCharArray();
        // 한글자씩 프린트 한다.
        for(i = 0; i < arr.Length; i++){
            yield return new WaitForSeconds(0.06f);
            if(arr[i] == '/') gameObject.GetComponent<Text>().text += "\n";
            else {gameObject.GetComponent<Text>().text += arr[i]; talkBgm.Play();}
        }
        // 프린트가 끝난 후
        nextButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
