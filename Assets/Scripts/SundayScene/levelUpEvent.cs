using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUpEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        churchManager.chLevel ++;
        if(churchManager.chLevel >= 4) churchManager.chLevel = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
