using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debtManager : MonoBehaviour
{
    public Text debtText, prptyText;
    public static int debt = 0;
    // Start is called before the first frame update
    void Start()
    {
        debt += itemManager.debtNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
