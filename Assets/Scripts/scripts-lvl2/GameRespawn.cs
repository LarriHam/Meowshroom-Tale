using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;

    void FixedUpdate() {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(40f, 0.02f, -33.46f);
            GameManager.health -= 1;
        }    
    }
}    
