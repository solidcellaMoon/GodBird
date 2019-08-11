using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcButton : MonoBehaviour
{
    public int type;
    public static int npcType;

    // Start is called before the first frame update
    void Start()
    {   
        if(!npcManager.npcList[type])
            gameObject.GetComponent<Image>().color = Color.black;
    }

    public void NpcClick(){
        InfoManager.type = type;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
