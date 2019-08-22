using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class storyClick : MonoBehaviour
{
    public GameObject[] textArr = new GameObject [4];
    public GameObject[] scene = new GameObject [4];
    int index = 0;
    public void scene1End(){
        scene[0].SetActive(false);
        scene[1].SetActive(true);
    }

    public void scene2End(){
        scene[1].SetActive(false);
        scene[2].SetActive(true);
    }

    public void scene3End(){
        if(index == textArr.Length - 1) SceneManager.LoadScene("eventScene");
        else {
            index ++;
            textArr[index-1].SetActive(false);
            textArr[index].SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
