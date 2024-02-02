using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playGUI : MonoBehaviour
{
    [SerializeField] public GameManager gm;
    [SerializeField] public PlayerStats player;

    [SerializeField] public SettingsPanel Settings;
    
    [SerializeField] public HealthBar hp;
    [SerializeField] public TextMeshProUGUI waveText;
    [SerializeField] public TextMeshProUGUI timerText;
    public void PauseGame()
    {
        Time.timeScale = 0;
        Settings.Open();
    }

    void FixedUpdate()
    {
        timerText.text = gm.Timer.ToString("");
        waveText.text = gm.Wave.ToString("");
        hp.n = player.mod_health;
    }
}
