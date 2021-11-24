using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public Button start_btn;
    public TMPro.TextMeshProUGUI final_msg;
    public GameManager gm;
    public StartScript sc;

    void Awake()
    {
        start_btn.onClick.AddListener(RestartGame);
    }

    public void EndGame()
    {
        gm.game_started = false;
        final_msg.text = "Game over!\nYour final score was " + gm.score.ToString();
        gameObject.SetActive(true);
    }

    void RestartGame()
    {
        sc.Restart();
        gameObject.SetActive(false);
    }
}
