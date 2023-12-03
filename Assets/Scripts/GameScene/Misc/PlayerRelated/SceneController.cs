using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        //time scale is 1 by default
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //if escape key is pressed, toggle pause state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
        
    }
    
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game

        // Disable components or scripts that control the game logic
        // For example, you can disable the PlayerController script:
        FindObjectOfType<PlayerController>().enabled = false;

        // Show the pause menu
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game

        // Enable components or scripts that were disabled during pause
        // For example, you can enable the PlayerController script:
        FindObjectOfType<PlayerController>().enabled = true;

        // Hide the pause menu
        pauseMenu.SetActive(false);
    }
    
    //method to reset current scene
    public void ResetScene()
    {
        //get current scene
        UnityEngine.SceneManagement.Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        //reload current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }
    
    //method to go to previous scene
    public void GoToPreviousScene()
    {
        //get current scene
        UnityEngine.SceneManagement.Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        //get current scene index
        int currentSceneIndex = currentScene.buildIndex;
        //load previous scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex - 1);
    }
    
    //method to go to main menu
    public void GoToMainMenu()
    {
        //load main menu scene without keeping current scene in memory
        
        //get current scenes
        UnityEngine.SceneManagement.Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        //get current scene index
        int currentSceneIndex = currentScene.buildIndex;
        //load main menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //unload current scene
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentSceneIndex);
        
        
    }
}
