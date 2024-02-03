using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandler : MonoBehaviour
{
    [SerializeField] public SettingsPanel SettingsPanel;

    //you can check build settings to manage change of scenes via index.
    // 0 = start menu
    // 1 = main game
    // 2 = credits
    // 3 = opening
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void DoOpening() {
        SceneManager.LoadScene(3);
    }
    public void OpenMainMenu() {
        SceneManager.LoadScene(0);
    }

    // Settings should just be an open window. Are we still making this?
    public void OpenSettings()
    {
        SettingsPanel.Open();
    }
    public void OpenCredits()
    {
        SceneManager.LoadScene(2);
    }
}
