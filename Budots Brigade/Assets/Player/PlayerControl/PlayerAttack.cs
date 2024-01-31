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
        equippedWeapon = equip;
        GameManager.Instance.StartTimer(equippedWeapon.Timer);
    }

    private void ThrowEquipped() {
        equippedWeapon = null;
        PlayerWeapon pw = weaponObj.GetComponent<PlayerWeapon>();
        pw.DequipWeapon();

        GameObject proj = Instantiate(throwProjectile, transform);
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        proj.transform.localPosition = (mousePos - (Vector2)transform.position).normalized;
        ProjectileVelocity pv = proj.GetComponent<ProjectileVelocity>();
        pv.SetValues((mousePos - (Vector2)transform.position).normalized, throwVelocity, GameManager.Instance.Timer);

        GameManager.Instance.StartNullWeaponTimer();
    }
}
