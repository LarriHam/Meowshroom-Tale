using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_01_PLayerMovement: MonoBehaviour
{
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalAxis, 0, verticalAxis);

        Debug.Log(movementDirection);

        // transform.position += movementDirection * Time.deltaTime * speed;

        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
    }
}
