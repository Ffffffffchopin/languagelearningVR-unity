using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    private HandwritingAgent hand;

    private Writing write;

    private void Start()
    {
        hand = FindObjectOfType<HandwritingAgent>();
        write = FindObjectOfType<Writing>();
    }
    public void ClearButton()
    {

        hand.parsedText = "";
        if (hand.textMesh) hand.textMesh.text = hand.parsedText;


        foreach (Transform line in write._lineParent)
        {
            Destroy(line.gameObject);
        }

        write._lastPredict = Time.time;
        write._lastPredictIdx = 0;
    }
}
