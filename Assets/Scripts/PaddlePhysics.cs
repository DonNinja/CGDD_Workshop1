using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePhysics : MonoBehaviour
{
    public float maxReflectAngle;
    public EndScript game_over;
    bool isMovingLeft;

    private void Awake()
    {
        isMovingLeft = false;
    }

    private void FixedUpdate()
    {
        // Check if game has started
        if (GameManager.instance.game_started)
        {
            if (PaddleController.instance.movingLeft && !isMovingLeft)
            {
                transform.Rotate(0, 0, 180);
                isMovingLeft = true;
            }
            else if (!PaddleController.instance.movingLeft && isMovingLeft)
            {
                transform.Rotate(0, 0, 180);
                isMovingLeft = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D ball = other.attachedRigidbody;
        bool good = other.gameObject.GetComponent<BallController>().good;
        bool lost = other.gameObject.GetComponent<BallController>().lost;
        if (ball != null)
        {
            // Remove ball from existence
            Destroy(ball);
            Destroy(other.gameObject);
            Destroy(other);

            // Add points or end game
            if (!lost)
            {
                if (good)
                    GameManager.instance.score += 1;
                else if (!good)
                    game_over.EndGame();
            }

            other.gameObject.GetComponent<BallController>().lost = true;
        }
    }
}
