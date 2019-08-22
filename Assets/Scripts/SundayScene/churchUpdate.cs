using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class churchUpdate : MonoBehaviour
{
    public GameObject church;
    public GameObject churchUI;

    // Start is called before the first frame update
    void Start()
    {
        church.GetComponent<SpriteRenderer>().sprite =
        Resources.Load<Sprite>("Buildings/"+churchManager.chLevel.ToString()) as Sprite;

    }

    // Update is called once per frame
    void Update()
    {
        if(churchUI.activeSelf){
            churchUI.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Buildings/"+churchManager.chLevel.ToString()+"_icon") as Sprite;
        }
    }
}
