using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttackController : MonoBehaviour
{
    public Image timeBarImage;
    public float totalTime = 3f;
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBarImage.fillAmount = timeLeft / totalTime;
        }
        else
        {
            //DialogManager dialog = GameObject.Find("DialogManager").GetComponent<DialogManager>();
            //dialog.NextOrOverCheck();
            Time.timeScale = 0;
        }
    }
}
