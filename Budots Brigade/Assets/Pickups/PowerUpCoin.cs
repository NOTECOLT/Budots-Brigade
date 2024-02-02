using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoin : Pickup {
    public modifiableStat pup_type;
    public float amount;

    public void SetType(modifiableStat stat, float amt) {
        pup_type = stat;
        amount = amt;
    }
}
