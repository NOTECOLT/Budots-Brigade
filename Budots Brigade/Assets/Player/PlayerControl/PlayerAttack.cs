using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public Camera cam;
    public Weapon equippedWeapon;
    void Start() {
        
    }

    void Update() {
        equippedWeapon.DoAttack(gameObject, cam.ScreenToWorldPoint(Input.mousePosition));
    }
}
