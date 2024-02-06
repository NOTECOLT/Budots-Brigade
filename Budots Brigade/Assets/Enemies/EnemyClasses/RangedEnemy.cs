using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Ranged", menuName = "Enemy/Ranged", order = 2)]
public class RangedEnemy : EnemyClass {
    public GameObject projectile;
    public float projectileVelocity;
    

    void Start() {
    }

    public override void Attack(GameObject playerObj) {
        AudioSource asrc = gameObject.GetComponent<AudioSource>();

        if (!asrc.isPlaying) {
            asrc.clip = AttackSFX[_r.Next(0, AttackSFX.Length)];
            asrc.Play();
        }
        
        GameObject bulletGameObject = Instantiate(projectile, this.gameObject.transform.position, Quaternion.identity);
        bulletGameObject.GetComponent<ProjectileVelocity>().SetValues(GetDirectionToPlayer(playerObj), projectileVelocity, 3.0f, AttackDamage, false);
    }

    Vector2 GetDirectionToPlayer(GameObject playerObj)
    {
        return (playerObj.transform.position - this.transform.position).normalized;
    }
}
