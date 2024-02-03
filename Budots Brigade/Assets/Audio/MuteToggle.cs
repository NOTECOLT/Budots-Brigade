using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteToggle : MonoBehaviour {
    public ToggleSetting setting;
    public void Toggle() {
        GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;
    }
    void Update() {
        switch (setting) {
            case ToggleSetting.TOGGLE_SFX:
                GetComponent<AudioSource>().mute = GameSettings.Instance.MuteSFX;
                break;
            case ToggleSetting.TOGGLE_BGM:
                GetComponent<AudioSource>().mute = GameSettings.Instance.MuteBGM;
                break;
            default:
                break;
        }
    }
}
