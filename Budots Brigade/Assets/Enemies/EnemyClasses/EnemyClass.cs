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
    protected GameObject player;
    
    float nextFire;

    void Awake()
    {
        nextFire = 0;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    public void DoAttack(GameObject playerObj) {
        if (Time.time > nextFire)
        {
            // Debug.Log("do attack");
            nextFire = Time.time + AttackCooldown;
            Attack(playerObj);
        }
    }

    public virtual void Attack(GameObject playerObj)
    {
        Debug.Log("attack");
    }
}
