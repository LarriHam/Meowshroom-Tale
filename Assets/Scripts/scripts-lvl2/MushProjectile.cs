using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushProjectile : MonoBehaviour
{
    //life is how long the bullet stays in the game when it's thrown
    public float life = 3;

    public float rotX = 5f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider other) 
    {

        if(other.gameObject.tag == "Enviornment")
        {            
            Destroy(gameObject);           
        }  
        
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            
        }        
       
    }

    //An attempt to take health away from enemy
    // private void OnCollisionEnter(Collision collision) 
    // {
    //     if(collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealthComponent))
    //     {
    //         enemyHealthComponent.TakeDamage(1);
    //     }

    //     Destroy(gameObject);
        
    // }


    void Update()
    {
        transform.Rotate(rotX, 0, 0);
    }
}

