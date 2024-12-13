using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private bool playerInTrigger = false;
    public GameObject instructionE;

    // Update is called once per frame
    void Update()
    {
        if(playerInTrigger)
        {
            if(Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene(sceneBuildIndex:1);
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
