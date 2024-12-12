using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScriptStationary : MonoBehaviour
{
    // public Transform targetObj;


    public Transform Player;
    public float MoveSpeed = 4;
    int MinDist = 10;

    private bool isAttacking = false;

    private Animator animator;

    // public GameObject enemey;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 5 * Time.deltaTime);
     

        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= MinDist && isAttacking == false)
        {
            this.gameObject.GetComponent<EnemyAi>().enabled=true;
            // transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            // animator.SetBool("IsWalking", true);
            animator.SetBool("IsAttacking", true);
            

        }else{
            this.gameObject.GetComponent<EnemyAi>().enabled=false;
            // animator.SetBool("IsWalking", false);
            animator.SetBool("IsAttacking", false);
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