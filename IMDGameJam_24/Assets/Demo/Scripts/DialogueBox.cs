using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    string[] dialogueParts;

    [SerializeField]
    TextMeshProUGUI textDisplay;

    int index = 0;

    private void Start()
    {
        if (textDisplay == null)
            this.enabled = false;
        textDisplay.text = "";
    }

    public void Next()
    {

        if (index < dialogueParts.Length)
            textDisplay.text = dialogueParts[index];
        else
            textDisplay.text = "";
        index++;

    }

    public void Clear()
    {
        textDisplay.text = "";
    }
}
