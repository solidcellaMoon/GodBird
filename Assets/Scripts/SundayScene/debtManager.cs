using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debtManager : MonoBehaviour
{
    public Text debtText, prptyText;
    public static int debt;
    // Start is called before the first frame update
    void Start()
    {
        debt = 100 + 50 * (dateManager.weekNum + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
