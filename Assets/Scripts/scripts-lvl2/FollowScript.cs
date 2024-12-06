using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    // public Transform targetObj;


    public Transform Player;
    public float MoveSpeed = 4;
    int MinDist = 10;

    private bool isAttacking = false;

    // public GameObject enemey;


    void Start()
    {

    }

    void Update()
    {
        // transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 5 * Time.deltaTime);
     

        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= MinDist && isAttacking == false)
        {
            this.gameObject.GetComponent<EnemyAi>().enabled=true;
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            

        }else{
            this.gameObject.GetComponent<EnemyAi>().enabled=false;
        }
        
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Ouchie");
            isAttacking = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("No Ouchie");
            isAttacking = false;
        }
    }
}