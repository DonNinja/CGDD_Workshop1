using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreLabel;

    private void Update()
    {
        scoreLabel.text = GameManager.instance.score.ToString();
    }
}
