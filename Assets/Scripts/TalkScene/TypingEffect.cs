using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    string orginText = "";
    Text typingText;
    int textCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        typingText = gameObject.GetComponent<Text>();
        if(typingText != null)
        {
            orginText = typingText.text;

            if(orginText.Length > 0)
            {
                typingText.text = "";
                typingText.text += orginText[textCount++];

                StartCoroutine("Typing");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing()
    {
        yield return new WaitForSeconds(0.1f);
        if(orginText.Length - textCount > 0)
        {
            typingText.text += orginText[textCount++];

            StartCoroutine("Typing");
        }
    }
}
