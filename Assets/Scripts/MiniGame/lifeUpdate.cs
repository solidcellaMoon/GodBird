using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeUpdate : MonoBehaviour
{
    public int num;

    // Update is called once per frame
    void Update()
    {
        if(num > lifeManager.lifeNum) GetComponent<Image>().enabled = false;
        else GetComponent<Image>().enabled = true;
    }

}
