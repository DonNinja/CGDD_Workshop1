using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D body;
    public Vector2 direction;
    public float impulse;
    public Vector2 levelBounds;

    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        // Reset so the starting impulse is applied
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        float ballAngle = Vector2.Angle(transform.position, body.velocity);
        if (ballAngle < 90 &&
            (transform.position.x < -levelBounds.x ||
            transform.position.x > levelBounds.x ||
            transform.position.y < -levelBounds.y ||
            transform.position.y > levelBounds.y))
        {
            Reset();
        }
    }

    public void Reset()
    {
        transform.position = startPosition;
        body.velocity = direction.normalized * impulse;

        // Reset score
        GameManager.instance.score = 0;
    }
}
