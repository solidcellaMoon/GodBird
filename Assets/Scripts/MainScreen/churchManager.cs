using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class churchManager : MonoBehaviour
{
    public static int chLevel = 0; // 기본 레벨은 0
    public static int[] chAbility = {0,1,5,10,100}; // 레벨에 따른 능력 

    public static int[] chDay = {1,2,3,4}; //레벨업하는 주차 (2019년엔 1,3,6,11)

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
