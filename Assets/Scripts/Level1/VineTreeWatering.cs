using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineTreeWatering : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    public GameObject dialogueWindow;
    private bool playerInTrigger = false;
    private string[] newLines = {"This tree looks dry.", "Maybe if I found some water..."};
    public GameObject instructionE;
    public GameObject waterCan;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(playerInTrigger)
        {
            if(Input.GetKeyDown("e"))
            {
                if(player.GetComponent<HasWaterCan>().hasWaterCan == true)
                {
                    instructionE.SetActive(false);
                    waterCan.SetActive(true);
                    animator.SetBool("beenWatered", true);
                    Destroy(this.GetComponent<BoxCollider>());
                    playerInTrigger = false;
                }
                if(player.GetComponent<HasWaterCan>().hasWaterCan == false)
                {
                    dialogueWindow.GetComponent<DialogueScript>().lines = newLines;
                    dialogueWindow.GetComponent<DialogueScript>().StartDialogueWindow();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
            instructionE.SetActive(true);
            playerInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player")
        {
            instructionE.SetActive(false);
            playerInTrigger = false;
        }
    }
}
