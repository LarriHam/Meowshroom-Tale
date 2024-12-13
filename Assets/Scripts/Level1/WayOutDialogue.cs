using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayOutDialogue : MonoBehaviour
{
    public GameObject dialogueWindow;
    private string[] newLines = {"This ladder looks like the way out of here!", "I better climb out now."};
    private bool playedOnce = false;
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player" && !playedOnce)
        {
            dialogueWindow.GetComponent<DialogueScript>().lines = newLines;
            dialogueWindow.GetComponent<DialogueScript>().StartDialogueWindow();
            playedOnce = true;
        }
    }
}
