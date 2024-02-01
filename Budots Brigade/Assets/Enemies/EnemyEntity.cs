using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour {
    public EnemyClass enemyClass;
    protected int _hp;
    void Start() {
        _hp = enemyClass.MaxHP;
    }

    void Update() {
        enemyClass.DoAI(gameObject);
    }
}
