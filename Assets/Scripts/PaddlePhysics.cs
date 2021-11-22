using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePhysics : MonoBehaviour
{
    public float maxReflectAngle;

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D ball = other.attachedRigidbody;
        if (ball != null)
        {
            Vector2 paddleNormal = transform.up;
            // Make sure to only bounce balls that come from the front
            float ballAngle = Vector2.Angle(paddleNormal, ball.velocity);

            if (ballAngle > 90)
            {
                // Reflect the ball's velociy about the paddle normal to get the ball's velocity
                Vector2 reflectedVelocity = Vector2.Reflect(ball.velocity, paddleNormal);

                // Now we clamp the reflection angle to maxReflectAngle
                // We want the signed angle so we know which direction to rotate it
                float reflectAngle = Vector2.SignedAngle(paddleNormal, reflectedVelocity);

                // Check if the bounce is too shallow
                if (Mathf.Abs(reflectAngle) > maxReflectAngle)
                {
                    // Figure out how far past the maximum angle we are
                    float deltaAngle = (Mathf.Sign(reflectAngle) * maxReflectAngle) - reflectAngle;
                    // A quaternion represents a rotation, in this case about the Z axis
                    Quaternion clampRotation = Quaternion.Euler(0, 0, deltaAngle);
                    // Multiplying a vector by a quaternion gives you that vector rotate by the quaternion
                    reflectedVelocity = clampRotation * reflectedVelocity;
                }

                // Update the ball's velocity to bounce it away
                ball.velocity = reflectedVelocity;

                // Points!!
                GameManager.instance.score++;
            }
        }
    }
}
