using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    private SpriteRenderer _spr;
    
    void Start() {
        _spr = GetComponent<SpriteRenderer>();
    }

   
    void Update() {
        
    }

    public void DequipWeapon() {
        _spr.sprite = null;
    }
}
