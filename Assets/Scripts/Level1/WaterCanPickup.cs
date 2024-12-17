using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCanPickup : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
    public GameObject dialogueWindow;
    private bool playerInTrigger = false;
    public GameObject instructionE;

    private string[] newLines = {"This watering can is full of water.", "I should be able to water those trees now!"};
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInTrigger)
        {
            if(Input.GetKeyDown("e"))
            {
                dialogueWindow.GetComponent<DialogueScript>().lines = newLines;
                dialogueWindow.GetComponent<DialogueScript>().StartDialogueWindow();
                player.GetComponent<HasWaterCan>().hasWaterCan = true;
                animator.SetBool("waterCanDisappear", true);
                instructionE.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
            instructionE.SetActive(true);
            playerInTrigger=true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player")
        {
            instructionE.SetActive(false);
            playerInTrigger=false;
        }
    }
}
