using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class churchManager : MonoBehaviour
{
    public static int chLevel = 0; // 기본 레벨은 0
    public static int[] chAbility = {0,1,5,10,100}; // 레벨에 따른 능력 
    public GameObject church;

    // Start is called before the first frame update
    void Start()
    {
        church.GetComponent<SpriteRenderer>().sprite =
        Resources.Load<Sprite>("Buildings/"+chLevel.ToString()) as Sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
