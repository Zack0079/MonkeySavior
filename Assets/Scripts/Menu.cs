using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with the name of your game scene
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with the name of your game scene
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
