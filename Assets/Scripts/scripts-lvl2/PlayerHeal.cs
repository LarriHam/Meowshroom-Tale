using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    public GameObject mushroomCount;

    // Update is called once per frame
    void Update()
    {
        if(mushroomCount.GetComponent<CollectibleCountHealth>().CollectibleCount() > 0 && GameManager.health < 4)
        {
            if(Input.GetKeyDown("q"))
            {
                GameManager.health++;
                mushroomCount.GetComponent<CollectibleCountHealth>().OnCollectibleUsed();
            }
        }
    }
}
