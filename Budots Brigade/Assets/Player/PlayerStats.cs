using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum modifiableStat {
    WALK_SPEED,
    DASH_MULT,
    DAMAGE_MULT,
    DAMAGE_BONUS,
    ATTACK_SPEED
}

public class PlayerStats : MonoBehaviour {
    public float    base_walkSpeed = 2f;
    public float    base_dashMult =  2.0f;
    public float    base_damMult =   1.0f;
    public float    base_damBonus =  0.0f;
    public float    base_atkSpeed =  1.0f;

    public float    mod_walkSpeed =  2f;
    public float    mod_dashMult =   2.0f;
    public float    mod_damMult =    1.0f;
    public float    mod_damBonus =   0.0f;
    public float    mod_atkSpeed =   1.0f;

    public string[] passiveEquipment;   //will work as a kind of history for now.
    
    [SerializeField] public PlayerMovement pm;

    public void modify_add(modifiableStat stat, float amount) {
        switch(stat) {
            case modifiableStat.WALK_SPEED:
                mod_walkSpeed = mod_walkSpeed + (amount);
                break;
            case modifiableStat.DASH_MULT:
                mod_dashMult = mod_dashMult + (amount);
                break;
            case modifiableStat.DAMAGE_MULT:
                mod_damMult = mod_damMult + (amount);
                break;
            case modifiableStat.DAMAGE_BONUS:
                mod_damBonus = mod_damBonus + (amount);
                break;
            case modifiableStat.ATTACK_SPEED:
                mod_atkSpeed = mod_atkSpeed + (amount);
                break;
            default:
                Debug.Log("Unrecognized stat increase");
                break;
        }
        pm.updateStats();
    }

    public void modify_mult(modifiableStat stat, float amount) {
        switch(stat) {
            case modifiableStat.WALK_SPEED:
                mod_walkSpeed = mod_walkSpeed * (amount);
                break;
            case modifiableStat.DASH_MULT:
                mod_dashMult = mod_dashMult * (amount);
                break;
            case modifiableStat.DAMAGE_MULT:
                mod_damMult = mod_damMult * (amount);
                break;
            case modifiableStat.DAMAGE_BONUS:
                mod_damBonus = mod_damBonus * (amount);
                break;
            case modifiableStat.ATTACK_SPEED:
                mod_atkSpeed = mod_atkSpeed * (amount);
                break;
            default:
                Debug.Log("Unrecognized stat increase");
                break;
        }
        pm.updateStats();
    }
}
