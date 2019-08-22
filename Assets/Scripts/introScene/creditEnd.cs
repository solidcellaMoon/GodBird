using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditEnd : MonoBehaviour
{
    public GameObject BasicUI;
    public GameObject EndingUI;
    // Start is called before the first frame update
    void Start()
    {
        EndingUI.SetActive(false);
        BasicUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
