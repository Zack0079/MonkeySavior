using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    public GameObject instructionsPanel; // Reference to the instructions panel

    void Start()
    {
        HideInstructions();
    }

    void Update()
    {
        // Show the instructions panel when TAB is held down
        if (Input.GetKey(KeyCode.Tab) && Time.timeScale == 1f)
        {
            ShowInstructions();
        }

        // Hide the instructions panel when TAB is released
        if (Input.GetKeyUp(KeyCode.Tab) && instructionsPanel.activeSelf)
        {
            HideInstructions();
        }
    }

    void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }
}
