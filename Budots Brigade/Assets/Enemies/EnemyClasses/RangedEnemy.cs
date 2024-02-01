using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Ranged", menuName = "Enemy/Ranged", order = 2)]
public class RangedEnemy : EnemyClass {
    public Projectile projectile;

    void Start()
    {

    }

    public override void Attack(PlayerHealth gameObject) {
        //Debug.Log("Ranged attack");
        GameObject bulletGameObject = Instantiate(projectile.gameObject, this.gameObject.transform.position, Quaternion.identity);
        bulletGameObject.GetComponent<Projectile>().Setup(GetDirectionToPlayer(gameObject));
    }

    Vector2 GetDirectionToPlayer(PlayerHealth playerHealth)
    {
        Vector2 direction = (playerHealth.gameObject.transform.position - this.transform.position).normalized;
        return direction;
    }
}
