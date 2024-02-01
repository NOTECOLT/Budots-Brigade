using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // public float    base_health =    100f;
    public float    base_walkSpeed = 2f;
    public float    base_dashMult =  2.0f;
    public float    base_damMult =   1.0f;
    public float    base_damBonus =  0.0f;
    public float    base_atkSpeed =  1.0f;

    // public float    mod_health =     100f;
    public float    mod_walkSpeed =  2f;
    public float    mod_dashMult =   2.0f;
    public float    mod_damMult =    1.0f;
    public float    mod_damBonus =   0.0f;
    public float    mod_atkSpeed =   1.0f;

    public string[] passiveEquipment;   //will work as a kind of history for now.
    
    [SerializeField] public PlayerMovement pm;

    public void modify_add(string stat, float amount)
    {
        switch(stat){
            case "health":
                // mod_health = mod_health + (amount);
                break;
            case "walkSpeed":
                mod_walkSpeed = mod_walkSpeed + (amount);
                break;
            case "dashMult":
                mod_dashMult = mod_dashMult + (amount);
                break;
            case "damMult":
                mod_damMult = mod_damMult + (amount);
                break;
            case "damBonus":
                mod_damBonus = mod_damBonus + (amount);
                break;
            case "atkSpeed":
                mod_atkSpeed = mod_atkSpeed + (amount);
                break;
            default:
                Debug.Log("Unrecognized stat increase");
                break;
        }
        Debug.Log("Updating walkSpeed");
        pm.updateStats();
    }

    public void modify_mult(string stat, float amount)
    {
        switch(stat){
            case "health":
                // mod_health = mod_health * (amount);
                break;
            case "walkSpeed":
                mod_walkSpeed = mod_walkSpeed * (amount);
                break;
            case "dashMult":
                mod_dashMult = mod_dashMult * (amount);
                break;
            case "damMult":
                mod_damMult = mod_damMult * (amount);
                break;
            case "damBonus":
                mod_damBonus = mod_damBonus * (amount);
                break;
            case "atkSpeed":
                mod_atkSpeed = mod_atkSpeed * (amount);
                break;
            default:
                Debug.Log("Unrecognized stat increase");
                break;
        }
        pm.updateStats();
    }
}
