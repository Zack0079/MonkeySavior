using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
  public static MainManager Instance;

  public int score = 0;
  public int health = 3;
  public int highestScore;
  public int difficulty = 1;

  private void Awake()
  {
    if (Instance != null)
    {
      //reset the value
      resetSorce();
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  public void resetSorce(){
      Instance.score = 0;
      Instance.health = 3;
      Instance.difficulty = 1;
  }
}
