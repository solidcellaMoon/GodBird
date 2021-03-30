using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class churchText : MonoBehaviour
{
    int chLevel;
    string chLv, chStr, chProf;
    public Text textArea;
    // Start is called before the first frame update
    void Start()
    {
        chLevel = churchManager.chLevel + 1;
        chLv = "Lv." + chLevel.ToString();

        switch(chLevel){
            case 1: chStr = "초라한 박스집"; 
                    chProf = "별 볼 일 없다."; break;
            case 2: chStr = "작은 오두막";
                    chProf = "아늑한 작은 나무집"; break;
            case 3: chStr = "평범한 건물";
                    chProf = "평범한 도시 건물"; break;
            case 4: chStr = "요즘 핫한 교회";
                    chProf = "요즘 유명한 바로 그 곳"; break;
            case 5: chStr = "신성한 대성당";
                    chProf = "새들의 신성한 성지"; break;
            default: break;
        }

        textArea.text = chStr;
        if(SceneManager.GetActiveScene().name == "SundayScene")
        textArea.text = chLv + " " + chStr + "\n" + chProf;
        else if (SceneManager.GetActiveScene().name == "MainScreen")
        textArea.text = chLv + "\n" + chStr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
