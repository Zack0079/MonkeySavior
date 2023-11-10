using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }
}
