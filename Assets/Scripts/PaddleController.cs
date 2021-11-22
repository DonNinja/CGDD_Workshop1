using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float rotationSpeed;
    public float movSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationSpeed = movSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationSpeed = -movSpeed;
        }
        else
        {
            rotationSpeed = 0;
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
    }
}
