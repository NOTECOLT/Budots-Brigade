using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class SettingsPanel : MonoBehaviour {
    // Start is called before the first frame update
    public void Open() {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
    }
    public void Hide() {
        if (GameManager.Instance == null) {
            GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 2000, 0);
        }
        
        GameManager.Instance?.ResumeGame();
    }
    void Update() {
        if (GameManager.Instance == null) return;

        if (GameManager.Instance.GamePaused) {
            GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        } else {
            GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 2000, 0);
        }
    }
}
