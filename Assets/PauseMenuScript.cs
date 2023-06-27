using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject menuButton;

    public InputAction menuControls;

    private bool paused = false;

    public void OnPaused(InputAction.CallbackContext context)
    {
        // Whenever is the Options Button (Playstation) or the Start Button (Xbox) is selected
        paused = context.action.triggered;
        paused = context.performed;

        // The player controls when if the game is paused or not during the match
        if (paused)
        {
            if (GameIsPaused)
            {
                // The game is unpaused and continues with the match
                Resume();
            }
            else
            {
                // The game is paused
                Pause();
            }
        }

    }

    private void OnEnable()
    {
        menuControls.Enable();
    }
    private void OnDisable()
    {
        menuControls.Disable();
    }

    public void Resume()
    {
        // If resume, the pause menu ui and menu button will be removed
        pauseMenuUI.SetActive(false);
        menuButton.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        // If paused, the pause menu ui and menu button will appear
        pauseMenuUI.SetActive(true);
        menuButton.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // If the player select to go back to the menu, it will reloacted the player back to the menu screen
        Time.timeScale = 1f;
        Debug.Log("Back To the Menu");
        SceneManager.LoadScene(1);


        // The whole gameplay will be reset
        GameManager.Instance.p1Damage = 0; 
        GameManager.Instance.p2Damage = 0;
        GameManager.Instance.p1Lives = 3;
        GameManager.Instance.p2Lives = 3;
        GameManager.Instance.countdownTimer = 150;
        GameManager.Instance.game_over = false;

        GameplayScript.Instance.p1Damagetxt.text = "P1: " + 0;
        GameplayScript.Instance.p2Damagetxt.text = "P2: " + 0;
        GameplayScript.Instance.p1Livestxt.text = "x " + 3;
        GameplayScript.Instance.p2Livestxt.text = "x " + 3;
        GameplayScript.Instance.countdownTimertxt.text = "TIME: " + 150; 



    }

}
