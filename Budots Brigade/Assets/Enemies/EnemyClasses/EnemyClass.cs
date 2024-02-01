using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyClass : MonoBehaviour {
    // GENERIC ENEMY CLASS -- Inherit from me!!
    public int MaxHP;
    public float Speed;
    public float Acceleration;
    public float AttackCooldown; // Time between
    public int AttackDamage;

    // player
    protected PlayerHealth playerHealth;
    
    float nextFire;

    void Awake()
    {
        nextFire = 0;
    }

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void DoAttack(PlayerHealth gameObject) {
        if (Time.time > nextFire)
        {
            // Debug.Log("do attack");
            nextFire = Time.time + AttackCooldown;
            Attack(gameObject);
        }
    }

    public virtual void Attack(PlayerHealth gameObject)
    {
        Debug.Log("attack");
    }
}
