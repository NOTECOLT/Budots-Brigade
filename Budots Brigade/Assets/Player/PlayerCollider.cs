using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] public PlayerStats stats;
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Pickup")) {
            if (other.GetComponent<PowerUpCoin>() == null) return;

            PowerUpCoin coinStats = other.gameObject.GetComponent<PowerUpCoin>();
            modifiableStat type = coinStats.pup_type; // gotta change this to equipment or make a new version.
            float amt = coinStats.amount;
            
            stats.modify_add(type, amt);
        }
    }
}
