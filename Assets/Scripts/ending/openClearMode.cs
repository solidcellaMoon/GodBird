using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openClearMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 게임을 클리어시 gameClear 변수를 true로 설정 (무제한 모드용)
        gameManager.gameClear = true;
        
    }
    
}
