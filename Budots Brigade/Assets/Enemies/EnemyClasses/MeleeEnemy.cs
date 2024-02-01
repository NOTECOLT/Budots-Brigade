using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[CreateAssetMenu(fileName = "Melee", menuName = "Enemy/Melee", order = 1)]
public class MeleeEnemy : EnemyClass {
    public override void Attack(GameObject gameObject) {
        Debug.Log("Melee attack");
    }
}
