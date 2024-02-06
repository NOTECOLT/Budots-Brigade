using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public static SceneChanger Instance { get; private set; }
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    private Animator anim;
    private int _nextScene;
    void Start() {
        anim = GetComponent<Animator>();
    }

    private void CueBlack() {
        anim.SetTrigger("Fade Out");
    }

    public void ChangeScene(Scenes scene) {
        _nextScene = (int)scene;
        CueBlack();
    }

    private void GoToNextScene() {
        Debug.Log("SCENE CHANGER going to " + _nextScene);
        SceneManager.LoadScene(_nextScene);
    }
}

public enum Scenes {
    MAINMENU,
    MAINGAME,
    CREDITS,
    OPENING,
    GAMEOVER
}
