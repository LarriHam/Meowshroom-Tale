using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public int index;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        index = 0;
        textComponent.text = lines[index];
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = lines[index];
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }
    public void StartDialogueWindow()
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
    }
}
