using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playGUI : MonoBehaviour
{
    [SerializeField] public GameManager gm;
    [SerializeField] public PlayerStats player;
    [SerializeField] public SpriteRenderer gun;

    [SerializeField] public SettingsPanel Settings;
    
    [SerializeField] public UnityEngine.UI.Image gunImage;
    [SerializeField] public TextMeshProUGUI waveText;
    [SerializeField] public TextMeshProUGUI timerText;
    public void PauseGame() {
        GameManager.Instance.PauseGame();
        // Settings.Open();
    }

    void FixedUpdate()
    {
        timerText.text = Mathf.FloorToInt(gm.Timer) + ":" + (int)(gm.Timer % 1 * 100);

        waveText.text = "Wave: " + gm.Wave;
        if (gun.sprite) {
            gunImage.sprite =  gun.sprite;
            gunImage.color = new Color(255, 255, 255, 1);
        }
        else {
            gunImage.sprite = null;
            gunImage.color = new Color(255, 255, 255, 0);
        }
    }
}
