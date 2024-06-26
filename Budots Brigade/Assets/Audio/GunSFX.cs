using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSFX : MonoBehaviour {
    public static GunSFX Instance { get; private set; }
    private AudioSource _src;
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    void Start() {
        _src = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip audio) {
        _src.clip = audio;
        _src.Play();
    }
}
