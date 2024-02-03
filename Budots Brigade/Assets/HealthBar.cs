using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    private Slider _s;

    void Start() {
        _s = GetComponent<Slider>();
    }

    void Update() {
        _s.value = GameManager.Instance.CurrentHP / GameManager.Instance.PlayerHP;
    }
}
