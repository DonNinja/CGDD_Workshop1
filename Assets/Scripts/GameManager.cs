using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject original_ball;
    public bool game_started;
    public int score;
    public int ball_count;
    public float ball_time;

    float init_time;
    float now_time;
    float min_time;

    void Awake()
    {
        // Set this to be the singleton instance
        instance = this;
        init_time = Time.time;
        game_started = false;
        ball_count = 0;
        min_time = 1f;
        ball_time = 3f;
    }

    void Update()
    {
        // Generate new balls based on time and if 
        if (game_started)
        {
            now_time = Time.time;
            if (now_time - init_time > ball_time)
            {
                ball_count++;
                Instantiate(original_ball);
                init_time = now_time;
                if (ball_time > min_time)
                    ball_time -= 0.25f;
            }
        }
    }
}
