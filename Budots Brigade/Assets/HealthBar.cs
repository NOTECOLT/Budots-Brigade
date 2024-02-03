using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    void Update() {
        GetComponent<Image>().fillAmount = GameManager.Instance.CurrentHP / GameManager.Instance.PlayerHP;
    }
}
