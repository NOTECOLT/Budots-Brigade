using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        SceneChanger.Instance.ChangeScene(Scenes.MAINGAME);
    }
    public void DoOpening() {
        SceneChanger.Instance.ChangeScene(Scenes.OPENING);
    }
    public void OpenMainMenu() {
        Time.timeScale = 1;
        SceneChanger.Instance.ChangeScene(Scenes.MAINMENU);
    }

    // Settings should just be an open window. Are we still making this?
    public void OpenSettings()
    {
        SettingsPanel.Open();
    }
    public void OpenCredits()
    {
        SceneChanger.Instance.ChangeScene(Scenes.CREDITS);
    }
}
