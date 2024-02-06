using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[CreateAssetMenu(fileName = "Melee", menuName = "Enemy/Melee", order = 1)]
public class MeleeEnemy : EnemyClass {
    public override void DoAttack(GameObject playerObj) {
        if (Time.time > nextFire) {
            nextFire = Time.time + AttackCooldown;
            anim.SetTrigger("Attack"); // Call to Attack is in the Animation

            if (!GetComponent<AudioSource>().isPlaying) {
                GetComponent<AudioSource>().clip = AttackSFX[_r.Next(0, AttackSFX.Length)];
                GetComponent<AudioSource>().Play();
            }
        }
    }
    public override void Attack(GameObject playerObj) {
        if (GetComponent<EnemyEntity>().IsWithinAttackRange){ // Do a second check in case the player moved out of ranged
            GameManager.Instance.DamagePlayer(AttackDamage);
            Debug.Log("Melee attack");
        }
    }
}
