using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour {
    public Camera cam;
    public Weapon equippedWeapon;
    public GameObject weaponObj;
    public GameObject throwProjectile;
    public float throwVelocity;
    
    void Start() {
        if (equippedWeapon != null) EquipWeapon(equippedWeapon);
    }

    void Update() {
        if (equippedWeapon == null) return;

        equippedWeapon.DoAttack(gameObject, cam.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetKeyUp(KeyCode.Q)) ThrowEquipped();
    }

    public void EquipWeapon(Weapon equip) {
        Debug.Log("Equipped " + equip.name);
        equippedWeapon = equip;
        GameManager.Instance.StartTimer(equippedWeapon.Timer);
        weaponObj.GetComponent<PlayerWeapon>().EquipWeapon(equip);
    }

    private void ThrowEquipped() {
        if (equippedWeapon == null) return;

        GameObject proj = Instantiate(throwProjectile, transform);
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        proj.transform.localPosition = (mousePos - (Vector2)transform.position).normalized;
        proj.transform.parent = null;
        proj.transform.localScale = Vector3.one * 0.5f;

        proj.GetComponent<SpriteRenderer>().sprite = equippedWeapon.Sprite;

        ProjectileVelocity pv = proj.GetComponent<ProjectileVelocity>();
        pv.SetValues((mousePos - (Vector2)transform.position).normalized, throwVelocity, GameManager.Instance.Timer, equippedWeapon.Damage, true);

        weaponObj.GetComponent<PlayerWeapon>().DequipWeapon();
        equippedWeapon = null;
        GameManager.Instance.StartNullWeaponTimer();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Pickup")) {
            
            if (other.GetComponent<WeaponPickup>() == null) return;
            if (equippedWeapon != null) return;

            EquipWeapon(other.GetComponent<WeaponPickup>().weapon);
        }
    }
}
