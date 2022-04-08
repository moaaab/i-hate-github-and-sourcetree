using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blink : MonoBehaviour
{
    [SerializeField] private string blinkText;
    public TextMeshProUGUI blinkingText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObjectDisappear(blinkingText, blinkText));
    }

    IEnumerator ObjectAppear(TextMeshProUGUI theText, string blinkText)
    {
        yield return new WaitForSeconds(1);
        theText.text = blinkText;
        StartCoroutine(ObjectDisappear(theText, blinkText));
    }

    IEnumerator ObjectDisappear(TextMeshProUGUI theText, string blinkText)
    {
        yield return new WaitForSeconds(1);
        theText.text = "";
        StartCoroutine(ObjectAppear(theText, blinkText));
    }
}
