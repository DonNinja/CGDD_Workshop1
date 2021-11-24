using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public static PaddleController instance;
    private float rotationSpeed;
    public float movSpeed;
    public bool movingLeft;

    void Awake()
    {
        // Set this to be the singleton instance
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movingLeft = false;
            rotationSpeed = movSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movingLeft = true;
            rotationSpeed = -movSpeed;
        }
        else
        {
            rotationSpeed = 0;
        }
    }

    void FixedUpdate()
    {
        if (GameManager.instance.game_started)
            transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
    }
}
