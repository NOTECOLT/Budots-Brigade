using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class Weapon : ScriptableObject {
    public string weaponName;
    public Sprite sprite;
    public float damage;
    public float timer;

}