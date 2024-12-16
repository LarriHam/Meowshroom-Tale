using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enviornment")
        {
            Destroy(this.gameObject);
            
        }
        
    }
}
