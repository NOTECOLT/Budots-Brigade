using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup {
    public Weapon weapon = null;
    void Start() {
        if (weapon != null) SetWeapon(weapon);
    }
    public void SetWeapon(Weapon weapon) {
        this.weapon = weapon;
        GetComponent<SpriteRenderer>().sprite = weapon.Sprite;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag != "Player") return;
        if (col.gameObject.GetComponent<PlayerAttack>().equippedWeapon != null) return; 
        
        Destroy(gameObject);
    }
}
