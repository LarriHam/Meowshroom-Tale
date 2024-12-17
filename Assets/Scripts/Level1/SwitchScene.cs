using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private bool playerInTrigger = false;
    public GameObject instructionE;
    public GameObject transition;

    // Update is called once per frame
    void Update()
    {
        if(playerInTrigger)
        {
            if(Input.GetKeyDown("e"))
            {
                transition.GetComponent<LevelLoader>().LoadNextLevel();
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
