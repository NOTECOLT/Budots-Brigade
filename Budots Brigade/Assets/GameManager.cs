using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance { get; private set; }
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public int PlayerHP = 100;
    public int Wave = 0;
    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private List<GameObject> _enemyPrefabs; // EnemyPrefabs[(int)EnemyType] to find the enemy prefab to instantiate

    void Start() {
    }

    
    void Update() {
        if (_enemyParent.transform.childCount == 0 && Wave < EnemyWaves.FINAL_WAVE) {
            SpawnNextWave();
        }
    }

    public void SpawnNextWave() {
        Wave++;
        Debug.Log("Spawning Wave " + Wave);
        
        Dictionary<EnemyType, int> currentWave = EnemyWaves.WaveList[Wave - 1];

        foreach (KeyValuePair<EnemyType, int> entry in currentWave) {
            for (int i = 0; i < entry.Value; i++) {
                GameObject enemy = SpawnEnemy(entry.Key);
            }
        }
    }

    private GameObject SpawnEnemy(EnemyType enemyType) {
        return Instantiate(_enemyPrefabs[(int)enemyType], _enemyParent.transform);
    }
}