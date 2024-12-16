using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDMG : MonoBehaviour
{

    public float amp = 0.5f;
    public float freq = 3f;
    Vector3 initPos;
    public float rotY = 1f;

    public static event Action OnCollected;
    
    void Start()
    {
        initPos = transform.position;
    }

    
    void Update()
    {
        //this makes the object move up and down
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, initPos.z);
        //this makes the object rotate
        transform.Rotate(0, rotY, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
