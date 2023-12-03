using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalEnemies = 0;
    public int defeadEnemies = 0;
    public SceneController sceneController;

    // Update is called once per frame
    void Update()
    {
        if(totalEnemies > 0 && defeadEnemies >0 && defeadEnemies >= totalEnemies){
          sceneController.NextLevel();
        }
    }
}
