using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    // public Transform targetObj;


    public Transform Player;
    public float MoveSpeed = 4;
    int MinDist = 10;

    // public GameObject enemey;
    // public string enemyAi.cs;

    // public enemyAI enemyScript;

    void Start()
    {
        // (enemy. GetComponent(scr) as MonoBehaviour).enabled = false;
    }

    void Update()
    {
        // transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 5 * Time.deltaTime);
     

        transform.LookAt(Player);
        // enemyScript.enabled=false;

        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            // (enemyAi.GetComponent(scr) as MonoBehaviour).enabled = true;
            this.gameObject.GetComponent<EnemyAi>().enabled=true;
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            

        }else{
            this.gameObject.GetComponent<EnemyAi>().enabled=false;
        }
        
    }
}
