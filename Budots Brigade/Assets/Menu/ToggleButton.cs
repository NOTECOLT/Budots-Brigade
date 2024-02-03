using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour {
    public ToggleSetting toggleSetting;
    
    void Start() {
        if (GameSettings.Instance != null) {
            switch (toggleSetting) {
                case ToggleSetting.TOGGLE_SFX:
                    GetComponent<Toggle>().isOn = !GameSettings.Instance.MuteSFX;
                    GetComponent<Toggle>().onValueChanged.AddListener( (bool value) => {
                        GameSettings.Instance.ToggleSFX(!value);
                    });
                    break;
                case ToggleSetting.TOGGLE_BGM:
                    GetComponent<Toggle>().isOn = !GameSettings.Instance.MuteBGM;
                    GetComponent<Toggle>().onValueChanged.AddListener( (bool value) => {
                        GameSettings.Instance.ToggleBGM(!value);
                    });
                    break;
                default:
                    break;
            }

        }
    }
}

public enum ToggleSetting {
    TOGGLE_SFX,
    TOGGLE_BGM
}
