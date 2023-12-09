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
        GameObject tmp  = GameObject.Find("MainManager"); 
        if(tmp != null){
          mainManager = tmp.GetComponent<MainManager>();
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
