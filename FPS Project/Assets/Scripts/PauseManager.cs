using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private MainMenu mainMenu;
    private bool isPaused = false;

    void Start()
    {
        mainMenu = Object.FindFirstObjectByType<MainMenu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        if (mainMenu == null) return;
        isPaused = true;
        Time.timeScale = 0f;
        mainMenu.ShowPauseMenu();
    }

    public void ResumeGame()
    {
        if (mainMenu == null) return;
        isPaused = false;
        Time.timeScale = 1f;
        mainMenu.HidePauseMenu();
    }
}
