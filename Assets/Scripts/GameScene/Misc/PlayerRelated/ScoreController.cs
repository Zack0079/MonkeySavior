using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;

    private MainManager mainManager;



    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        if(mainManager != null){
          score = mainManager.score;
        }

        scoreText.text = "Score: " + score;
    }


    public void AddScore(int amount)
    {
        if(mainManager != null){
            mainManager.score = score;
        }

        score += amount;
        scoreText.text = "Score: " + score;
    }
}
