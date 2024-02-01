using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyClass : MonoBehaviour {
    // GENERIC ENEMY CLASS -- Inherit from me!!
    public int MaxHP;
    public float Speed;
    public float AttackCooldown; // Time between
    
    float nextFire;

    void Awake()
    {
        nextFire = 0;
    }

    public void DoAttack(GameObject gameObject) {
        if (Time.time > nextFire)
        {
            Debug.Log("do attack");
            nextFire = Time.time + AttackCooldown;
            Attack(gameObject);
        }
    }

    public virtual void Attack(GameObject gameObject)
    {
        Debug.Log("attack");
    }
}
