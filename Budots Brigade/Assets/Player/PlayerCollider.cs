using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] public PlayerStats stats;
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other){
            if(other.CompareTag("PowerUp"))
            {
                PowerUpCoin coin = other.gameObject.GetComponent<PowerUpCoin>();
                string type = coin.pup_type; // gotta change this to equipment or make a new version.
                float amt = coin.amount;
                
                stats.modify_add(type, amt);
                coin.Despawn();
            }
        }
    }
}
