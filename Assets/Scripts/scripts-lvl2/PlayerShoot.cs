using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform mushSpawnPoint;
    public GameObject mushPrefab;
    public float mushSpeed = 10; 
    public GameObject mushroomCount;

    void Update()
    {
        if(mushroomCount.GetComponent<CollectibleCountDMG>().CollectibleCount() > 0)
        {
            if(Input.GetKeyDown("f"))
        {
            var bullet = Instantiate(mushPrefab, mushSpawnPoint.position, mushSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = mushSpawnPoint.forward * mushSpeed;
            mushroomCount.GetComponent<CollectibleCountDMG>().OnCollectibleUsed();
        }
        }
    }
}
