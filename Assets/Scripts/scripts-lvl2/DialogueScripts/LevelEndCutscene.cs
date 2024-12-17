using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCutscene : MonoBehaviour
{
    public GameObject dialogueWindow;
    private bool entered = false;
    public GameObject mushroomCountHeal;
    public GameObject mushroomCountDMG;
    private string[] newLines1 = {"Oh! You're here, Mushy!", 
    "You... Didn't bring any mushrooms like I asked you.", 
    "Well then, I guess there's always next time."};
    private int[] newSprites1 = {1,2,2};
    private string[] newLines2 = {"Oh! You're here, Mushy!", 
    "Ooooh, I see you brought plenty of brown mushrooms!", 
    "I will make some delicious dinner with this.", 
    "Don't slack though, Mushy! Dinner won't cook itself!"};
    private int[] newSprites2 = {1,1,1,1};
    private string[] newLines3 = {"Oh! You're here, Mushy!", 
    "Ah! So many red mushrooms!", 
    "I can finally make poison to get rid of that one hag...", 
    "Oh, don't worry about that, Mushy! Come on, help me prepare dinner!"};
    private int[] newSprites3 = {1,1,2,1};
    private string[] newLines4 = {"Oh! You're here, Mushy!", 
    "You brought so many different mushrooms!", 
    "I could make so many things with those...", 
    "Hey, Mushy, go help me make some potions!"};
    private int[] newSprites4 = {1,1,1,1};
    private string[] newLines5 = {"Oh! You're here, Mushy!", 
    "You brought... very few mushrooms, I see.", 
    "Grr... You know I can't cook much with so few!", 
    "Well then, I guess there's always next time."};
    private int[] newSprites5 = {1,2,2,1};
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        if (!entered)
        {
            Time.timeScale = 0;
            if(mushroomCountHeal.GetComponent<CollectibleCountHealth>().CollectibleCount() < mushroomCountDMG.GetComponent<CollectibleCountDMG>().CollectibleCount())
            {
                dialogueWindow.GetComponent<DialogueWithWitch>().lines = newLines3;
                dialogueWindow.GetComponent<DialogueWithWitch>().sprites = newSprites3;
            }
            if(mushroomCountHeal.GetComponent<CollectibleCountHealth>().CollectibleCount() > mushroomCountDMG.GetComponent<CollectibleCountDMG>().CollectibleCount())
            {
                dialogueWindow.GetComponent<DialogueWithWitch>().lines = newLines2;
                dialogueWindow.GetComponent<DialogueWithWitch>().sprites = newSprites2;
            }
            if(mushroomCountHeal.GetComponent<CollectibleCountHealth>().CollectibleCount() == mushroomCountDMG.GetComponent<CollectibleCountDMG>().CollectibleCount())
            {
                dialogueWindow.GetComponent<DialogueWithWitch>().lines = newLines4;
                dialogueWindow.GetComponent<DialogueWithWitch>().sprites = newSprites4;
            }
            if(mushroomCountHeal.GetComponent<CollectibleCountHealth>().CollectibleCount() == 0 && mushroomCountDMG.GetComponent<CollectibleCountDMG>().CollectibleCount() == 0)
            {
                dialogueWindow.GetComponent<DialogueWithWitch>().lines = newLines1;
                dialogueWindow.GetComponent<DialogueWithWitch>().sprites = newSprites1;
            }
            if(mushroomCountHeal.GetComponent<CollectibleCountHealth>().CollectibleCount() + mushroomCountDMG.GetComponent<CollectibleCountDMG>().CollectibleCount() >= 1 && mushroomCountHeal.GetComponent<CollectibleCountHealth>().CollectibleCount() + mushroomCountDMG.GetComponent<CollectibleCountDMG>().CollectibleCount() <= 2)
            {
                dialogueWindow.GetComponent<DialogueWithWitch>().lines = newLines5;
                dialogueWindow.GetComponent<DialogueWithWitch>().sprites = newSprites5;
            }
            dialogueWindow.GetComponent<DialogueWithWitch>().StartDialogueWindow();
            entered = true;
        }
    }
}
