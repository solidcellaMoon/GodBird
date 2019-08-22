using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionController : MonoBehaviour
{
    public static string name;
    void OnEnable(){

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(name != ""){
        GetComponent<Animator>().runtimeAnimatorController =
        Resources.Load<RuntimeAnimatorController>("motion/"+name) as RuntimeAnimatorController;
        }
        if(!DialogManager.check){
            GetComponent<SpriteRenderer>().color = new Color32(255,255,255,0);
        } else {
            GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
        }
    }

}
