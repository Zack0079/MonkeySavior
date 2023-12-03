using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndMenu : MonoBehaviour
{
    private MainManager mainManager;
    public TextMeshProUGUI score;

    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();

        if (mainManager != null)
        {
            int tmpscore = mainManager.score;
            if (mainManager.health > 3)
            {
                tmpscore += (mainManager.health - 3) * 10;
            }
            score.text = tmpscore + "";
        }

    }

    public void RestartGame()
    {
        if (mainManager != null)
        {
            mainManager.resetSorce();
        }
        SceneManager.LoadScene("Level1"); // Replace with the name of your game scene
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
