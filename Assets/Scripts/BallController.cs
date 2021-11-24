using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 init_direction;
    public Vector2 levelBounds;
    public Vector2 closeBounds;
    public SpriteRenderer sprite_renderer;
    public Sprite good_crate;
    public Sprite bad_crate;

    public Rigidbody2D body;
    public float impulse;
    public GameObject pointer;
    public Vector3 totalScale;

    float rotation_speed;
    Vector2 direction;
    Vector2 startPosition;
    public bool good;
    bool lost = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set first 5 as always good
        if (GameManager.instance.ball_count > 3)
        {
            if (Random.Range(0, 100) > 25)
                good = true;
            else
                good = false;
        }
        else
            good = true;

        // Set sprite's values
        sprite_renderer.sprite = good ? good_crate : bad_crate;
        rotation_speed = Random.Range(50, 1000);
        startPosition = transform.position;
        impulse = Random.Range(3f, 6f);

        // Set first direction as the base
        if (GameManager.instance.ball_count == 1)
            direction = init_direction;
        else
            direction = Random.insideUnitCircle.normalized;

        // Hide object
        gameObject.SetActive(false);

        // Create pointer and rotate it to correct position
        pointer = Instantiate(pointer, new Vector3(0, 0, 0), Quaternion.FromToRotation(init_direction, -direction));

        totalScale = transform.localScale;

        Invoke("RemovePointer", 1.5f);

        Invoke("Reset", 1);
    }

    void RemovePointer()
    {
        Destroy(pointer);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < totalScale.x && transform.localScale.y < totalScale.y)
        {
            transform.localScale *= 1.005f;
        }
        else
        {
            body.velocity = direction.normalized * impulse;
            float ballAngle = Vector2.Angle(transform.position, body.velocity);

            // Check if ball has exited the level bounds
            if (ballAngle < 90 &&
                (transform.position.x < -levelBounds.x ||
                transform.position.x > levelBounds.x ||
                transform.position.y < -levelBounds.y ||
                transform.position.y > levelBounds.y))
            {
                Destroy(gameObject);
            }

            // Check if ball has no possibility of scoring
            if (ballAngle < 90 &&
                (transform.position.x < -closeBounds.x ||
                transform.position.x > closeBounds.x ||
                transform.position.y < -closeBounds.y ||
                transform.position.y > closeBounds.y) && !lost)
            {
                GameManager.instance.score -= good ? 1 : 0;
                lost = true;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotation_speed * Time.deltaTime);
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        transform.localScale = new Vector3((float).1, (float).1, 1);
        transform.position = startPosition;
    }
}
