using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blink : MonoBehaviour
{
    public TextMeshProUGUI blinkingText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObjectDisappear(blinkingText));
    }

    IEnumerator ObjectAppear(TextMeshProUGUI theText)
    {
        yield return new WaitForSeconds(1);
        theText.text = "PRESS ENTER TO INSERT CREDIT";
        StartCoroutine(ObjectDisappear(theText));
    }

    IEnumerator ObjectDisappear(TextMeshProUGUI theText)
    {
        yield return new WaitForSeconds(1);
        theText.text = "";
        StartCoroutine(ObjectAppear(theText));
    }
}
