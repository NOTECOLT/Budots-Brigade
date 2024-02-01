using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HP;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        animator.SetTrigger("PlayerDamage");
        HP -= damage;
        if (HP <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        Debug.Log("Player is dead");
    }
}
