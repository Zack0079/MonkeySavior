using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the settings panel
    public GameObject menuPanel; // Reference to the menu panel

    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Replace with the name of your game scene
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level1"); // Replace with the name of your game scene
    }

    public void Settings()
    {
        // Turn off the menu panel and turn on the settings panel
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Back()
    {
        // Turn off the settings panel and turn on the menu panel
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}