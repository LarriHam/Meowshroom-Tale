using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWithWitch : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject witchHappy;
    public GameObject witchUpset;
    public string[] lines;
    public int[] sprites;
    public int index;
    public GameObject levelLoader;

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
        switch(sprites[index])
            {
                case 1:
                witchHappy.SetActive(true);
                break;
                case 2:
                witchUpset.SetActive(true);
                break;
                default:
                break;
            }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            witchHappy.SetActive(false);
            witchUpset.SetActive(false);
            index++;
            textComponent.text = lines[index];
            switch(sprites[index])
            {
                case 1:
                witchHappy.SetActive(true);
                break;
                case 2:
                witchUpset.SetActive(true);
                break;
                default:
                break;
            }
        }
        else 
        {
            gameObject.SetActive(false);
            levelLoader.GetComponent<LevelLoader>().LoadCongratsScreen();
            Time.timeScale = 1;
        }
    }
    public void StartDialogueWindow()
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
    }
}
