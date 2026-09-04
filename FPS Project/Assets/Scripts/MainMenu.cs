using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for loading scenes

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuCameraObject;
    [SerializeField] private GameObject menuCanvasObject;

    [SerializeField] private GameObject mainMenuPanel; // The Main Title/Play button group
    [SerializeField] private GameObject pausePanel;     // The Pause buttons group

    [SerializeField] private Image fadeOverlay;
    [SerializeField] private float fadeDuration = 1.0f; // Time in seconds to fade out

    // Call this function when the Play button is pressed
    private void Start()
    {
        ResetMenuState();
    }

    private void ResetMenuState()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        menuCameraObject.SetActive(true);
        menuCanvasObject.SetActive(true);
        mainMenuPanel.SetActive(true);
        pausePanel.SetActive(false);

        // Crucial Fix: Force the fade overlay to be completely clear on boot/reset
        if (fadeOverlay != null)
        {
            Color c = fadeOverlay.color;
            c.a = 0f;
            fadeOverlay.color = c;
        }
    }

    public void PlayGame()
    {
        // Start the fade out process instead of loading instantly
        StartCoroutine(FadeAndLoad());
    }
    private IEnumerator FadeAndLoad()
    {
        if (fadeOverlay == null) yield break;

        float timer = 0f;
        Color col = fadeOverlay.color;

        // FADE TO BLACK (no relation)
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            col.a = Mathf.Clamp01(timer / fadeDuration);
            fadeOverlay.color = col;
            yield return null;
        }

        // ASYNC LOAD THE GAMEPLAY SCENE
        // Using Async prevents the game from freezing mid-fade
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

        // Wait until the gameplay scene is 100% loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // SWITCH CAMERAS
        // Turn off the menu camera so the gameplay MainCamera takes over visuals
        menuCameraObject.SetActive(false);
        mainMenuPanel.SetActive(false); // Hide the title menu panel so it's gone when unpausing

        // FADE FROM BLACK (also no relation)
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            col.a = Mathf.Clamp01(1f - (timer / fadeDuration));
            fadeOverlay.color = col;
            yield return null;
        }

        // CLEANUP
        // Now that the transition is completely done, shut off the menu canvas entirely
        menuCanvasObject.SetActive(false);
    }

    // Call this function when the Quit button is pressed
    public void QuitGame()
    {
        Debug.Log("Quit game requested."); // Confirms functionality inside the Unity Editor
        Application.Quit(); // Closes the built application
    }

    public void ShowPauseMenu()
    {
        // Re-enable the menu objects overlaying the game
        menuCameraObject.SetActive(true);
        menuCanvasObject.SetActive(true);

        pausePanel.SetActive(true);     // Turn ONLY the pause menu visuals on
        mainMenuPanel.SetActive(false); // Make sure main titles remain hidden

        // Unlock the cursor so the player can click buttons
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HidePauseMenu()
    {
        // Hide the menu objects again
        menuCameraObject.SetActive(false);
        menuCanvasObject.SetActive(false);
        pausePanel.SetActive(false);

        // Re-lock the cursor for your Shooter mechanics
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // The Resume Button will link directly here
    public void ResumeFromButton()
    {
        PauseManager pm = Object.FindFirstObjectByType<PauseManager>();
        if (pm != null)
        {
            pm.ResumeGame(); // This handles unfreezing time and hiding the menu safely
        }
    }
    public void QuitToMainMenu()
    {
        // Unfreeze time so the game loop doesn't stay frozen forever
        Time.timeScale = 1f;

        // Unload the gameplay scene (Index 1) from the background
        SceneManager.UnloadSceneAsync(1);

        // Reset the visual panels back to standard Title Screen state
        menuCameraObject.SetActive(true);
        menuCanvasObject.SetActive(true);

        mainMenuPanel.SetActive(true); // Bring back "PLAY" and Titles
        pausePanel.SetActive(false);    // Hide the pause overlay

        // Free the cursor so they can navigate the title menu again
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}