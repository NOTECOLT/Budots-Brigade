using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : ScriptableObject {
    public string Name;
    public Sprite Sprite;
    public float Damage;
    public float Timer;
    public WeaponType Type;
    public float Cooldown;
    public AudioClip[] SFX;

    /// <summary></summary>
    /// <param name="obj">Assumed that this will be the gameobject of the in-world weapon itself.</param>
    public virtual int DoAttack(GameObject obj, Vector2 mousePos) { 
        return 0; 
    }
}

public enum WeaponType {
    Hitscan,
    Projectile,
    Melee,
    Special
}