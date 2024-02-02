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
    public float PlayerHP = 100;
    private float _currentHP;
    public float Timer { get; private set; }
    public int Wave = 0;
    public Vector2 SpawnCenter = Vector2.zero;
    public Vector2 SpawnRadius;

    private System.Random _r;
    
    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private List<GameObject> _enemyPrefabs; // EnemyPrefabs[(int)EnemyType] to find the enemy prefab to instantiate

    void Start() {
        _currentHP = PlayerHP;
        _r = new System.Random();
    }

    
    void Update() {
        if (_currentHP <= 0) Debug.Log("PLAYER DIED");

        if (_enemyParent.transform.childCount == 0) {
            SpawnNextWave();
        }

        if (Timer > 0) {
            Timer -= Time.deltaTime;
        } else {    
            _currentHP = 0;
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
        
        Dictionary<EnemyType, int> currentWave = EnemyWaves.WaveList[Wave % EnemyWaves.WAVE_LIST_LEN];

        foreach (KeyValuePair<EnemyType, int> entry in currentWave) {
            for (int i = 0; i < entry.Value * Mathf.Ceil(Wave / EnemyWaves.WAVE_LIST_LEN); i++) {
                GameObject enemy = SpawnEnemy(entry.Key);
                Vector2 minSpawn = SpawnCenter - SpawnRadius;
                Vector2 maxSpawn = SpawnCenter + SpawnRadius;
                enemy.transform.position = new Vector3(_r.Next((int)minSpawn.x, (int)maxSpawn.x),
                                                        _r.Next((int)minSpawn.y, (int)maxSpawn.y), 0);
            }
        }
    }

    public void DamagePlayer(float damage) {
        _currentHP -= damage;
    }

    private GameObject SpawnEnemy(EnemyType enemyType) {
        return Instantiate(_enemyPrefabs[(int)enemyType], _enemyParent.transform);
    }
}