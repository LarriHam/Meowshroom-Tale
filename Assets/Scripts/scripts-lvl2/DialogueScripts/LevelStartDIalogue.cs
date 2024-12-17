using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartDIalogue : MonoBehaviour
{

    public GameObject dialogueWindow;
    private string[] newLines = {"Finally, I'm out of this well!", "Home should be close by...", "I should pick up all those mushrooms I dropped.", "If anyone attacks me, I could throw a red one using \"F\".", "If they hit me, I should eat a brown one using \"Q\"...", "But I should bring home as many mushrooms as I can!"};
    // Start is called before the first frame update
    void Start()
    {
        dialogueWindow.GetComponent<DialogueScript>().lines = newLines;
        dialogueWindow.GetComponent<DialogueScript>().StartDialogueWindow();
    }
}
