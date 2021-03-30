using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditEnd : MonoBehaviour
{
    public GameObject BasicUI;
    public GameObject EndingUI;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "IntroScene"){
            EndingUI.SetActive(false);
            BasicUI.SetActive(true);
        }

        if(SceneManager.GetActiveScene().name == "ending"){
            EndingUI.SetActive(false);
            SceneManager.LoadScene("IntroScene");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
