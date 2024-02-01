using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Ranged", menuName = "Enemy/Ranged", order = 2)]
public class RangedEnemy : EnemyClass {
    public override void Attack(GameObject gameObject) {
        Debug.Log("Ranged attack");
    }
}
