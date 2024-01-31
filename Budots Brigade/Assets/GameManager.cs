using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] private float _nullWeaponTimer;
    public int PlayerHP = 100;
    public float Timer { get; private set; }
    public int Wave = 0;
    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private List<GameObject> _enemyPrefabs; // EnemyPrefabs[(int)EnemyType] to find the enemy prefab to instantiate

    void Start() {
    }

    
    void Update() {
        if (PlayerHP <= 0) Debug.Log("PLAYER DIED");

        if (_enemyParent.transform.childCount == 0 && Wave < EnemyWaves.FINAL_WAVE) {
            SpawnNextWave();
        }

        if (Timer > 0) {
            Timer -= Time.deltaTime;
        } else {    
            Instance.PlayerHP = 0;
        }
    }

    public void StartTimer(float sec) {
        Timer = sec;
    }

    public void StartNullWeaponTimer() {
        StartTimer(_nullWeaponTimer);
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