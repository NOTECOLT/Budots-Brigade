using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : ScriptableObject {
    // GENERIC ENEMY CLASS -- Inherit from me!!
    public int MaxHP;
    public float Speed;
    public float AttackCooldown; // Time between

    public virtual void DoAI(GameObject gameObject) {
        
    }
}
