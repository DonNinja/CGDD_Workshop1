using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public Button start_btn;
    public GameManager gm;

    private void Awake()
    {
        Restart();
        start_btn.onClick.AddListener(StartGame);
    }

    public void Restart()
    {
        gm.game_started = false;
        gm.ball_count = 0;
        gm.score = 0;
        gm.ball_time = 3f;
        gameObject.SetActive(true);
    }

    void StartGame()
    {
        gm.game_started = true;
        gameObject.SetActive(false);
    }
}
