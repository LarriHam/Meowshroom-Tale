using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HasWaterCan : MonoBehaviour
{
    public bool hasWaterCan = false;
    public GameObject waterCan;

    private void FixedUpdate() {
        if(hasWaterCan)
        {
            waterCan.SetActive(true);
        }
    }
}
