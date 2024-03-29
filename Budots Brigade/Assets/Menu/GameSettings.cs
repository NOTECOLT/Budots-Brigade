using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    public static GameSettings Instance { get; private set; }
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }        
    }

    public bool MuteBGM = false;
    public bool MuteSFX = false;

    public void ToggleBGM(bool value) {
        MuteBGM = value;
    }

    public void ToggleSFX(bool value) {
        MuteSFX = value;
    }
}
