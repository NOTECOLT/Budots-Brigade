using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playGUI : MonoBehaviour
{
    [SerializeField] public SettingsPanel Settings;

    public void PauseGame()
    {
        Time.timeScale = 0;
        Settings.Open();
    }
}
