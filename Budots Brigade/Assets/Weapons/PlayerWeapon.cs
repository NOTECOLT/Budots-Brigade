using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    
    public void EquipWeapon(Weapon equip) {
        GetComponent<SpriteRenderer>().sprite = equip.Sprite;
    }

    public void DequipWeapon() {
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
