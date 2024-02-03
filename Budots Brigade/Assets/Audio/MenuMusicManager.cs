using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour {
    public static MenuMusicManager Instance { get; private set; }
    void Awake() {
        if ((Instance != null && Instance != this)) {
            Destroy(gameObject);
        } else {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        
    }

    void Update() {
        if (GameManager.Instance != null) Destroy(gameObject);
    }
}
