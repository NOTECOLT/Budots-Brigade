using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteToggle : MonoBehaviour {
    public ToggleSetting setting;
    public void Toggle() {
        GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;
    }

    [SerializeField] private float amp = 0;
    void Update() {
        if (GameSettings.Instance == null) return;
        
        switch (setting) {
            case ToggleSetting.TOGGLE_SFX:
                GetComponent<AudioSource>().mute = GameSettings.Instance.MuteSFX;
                GetComponent<AudioSource>().volume = 0.4f + amp;
                break;
            case ToggleSetting.TOGGLE_BGM:
                GetComponent<AudioSource>().mute = GameSettings.Instance.MuteBGM;
                GetComponent<AudioSource>().volume = 0.35f;
                break;
            default:
                break;
        }
    }
}
