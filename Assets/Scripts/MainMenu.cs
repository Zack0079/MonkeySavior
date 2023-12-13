using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the settings panel
    public GameObject menuPanel; // Reference to the menu panel
    private MainManager mainManager;
    private SoundManager soundManager;
    public Slider slider;

    void Start(){
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        if(SceneManager.GetActiveScene().buildIndex == 0){
          soundManager = GameObject.Find("MainManager").GetComponent<SoundManager>();
          soundManager.resetSlider(slider);
        }
    }

    public void StartGame()
    {
        if(mainManager != null){
          mainManager.resetSorce();
          mainManager.mulitplayerMode= false;
        }
        SceneManager.LoadScene("Level1"); // Replace with the name of your game scene
    }


    public void MultiGame()
    {
        if(mainManager != null){
          mainManager.resetSorce();
          mainManager.mulitplayerMode= true;
        }
        SceneManager.LoadScene("MultiLevel"); // Replace with the name of your game scene
    }

    public void LoadGame()
    {
        if(mainManager != null){
          mainManager.resetSorce();
        }
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