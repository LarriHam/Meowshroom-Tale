using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform mushSpawnPoint;
    public GameObject mushPrefab;
    public float mushSpeed = 10; 

    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            var bullet = Instantiate(mushPrefab, mushSpawnPoint.position, mushSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = mushSpawnPoint.forward * mushSpeed;
        }
    }
        
 
}
