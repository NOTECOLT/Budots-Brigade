using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance { get; private set; }
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }

        audioSrc = GetComponent<AudioSource>();
    }
    public GameObject Player;
    [SerializeField] private float _nullWeaponTimer;
    public float PlayerHP = 100;
    public float CurrentHP { get; private set; }
    public float Timer;
    public bool GamePaused = false;
    public int Wave = 0;
    public Vector2 SpawnCenter = Vector2.zero;
    public Vector2 SpawnRadius;

    private System.Random _r;
    private AudioSource audioSrc;
    public AudioClip timerWarningSFX;
    // public AudioClip explosionSFX;

    public GameObject explosionVFX;
    
    
    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private List<GameObject> _enemyPrefabs; // EnemyPrefabs[(int)EnemyType] to find the enemy prefab to instantiate
    void Start() {
        CurrentHP = PlayerHP;
        _r = new System.Random();
    }

    
    void Update() {
        if (CurrentHP <= 0) SceneManager.LoadScene(4);

        if (_enemyParent.transform.childCount == 0) {
            SpawnNextWave();
        }

        if (Timer > 0) {
            Timer -= Time.deltaTime;

            if (Timer <= audioSrc.clip.length && !audioSrc.isPlaying) {
                audioSrc.clip = timerWarningSFX;
                audioSrc.Play();
            }
        } else {    
            SpawnExplosion(Player.transform.position);
            DamagePlayer(20);
            StartNullWeaponTimer();
            Timer += 2.0f;
        }

        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (!GamePaused) {
                PauseGame();
            } else {
                ResumeGame();
            }
        }
    }

    private void SpawnExplosion(Vector2 position) {
        Instantiate(explosionVFX, position, Quaternion.identity);
        // audioSrc.clip = explosionSFX;
        // audioSrc.Play();
    }

    public void PauseGame() {
        Time.timeScale = 0;
        GamePaused = true;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        GamePaused = false;
    }

    public void StartTimer(float sec) {
        Timer = sec;

        if (audioSrc.isPlaying) {
            audioSrc.Stop();
        }
    }

    public void StartNullWeaponTimer() {
        Timer = _nullWeaponTimer;
    }

    public void SpawnNextWave() {
        Wave++;
        Debug.Log("Spawning Wave " + Wave);
        
        Dictionary<EnemyType, int> currentWave = EnemyWaves.WaveList[(Wave - 1) % EnemyWaves.WAVE_LIST_LEN];

        foreach (KeyValuePair<EnemyType, int> entry in currentWave) {
            int scaler = (Wave < 5) ? 1 : (int)Mathf.Ceil(Wave / EnemyWaves.WAVE_LIST_LEN);

            for (int i = 0; i < entry.Value * scaler; i++) {
                GameObject enemy = SpawnEnemy(entry.Key);
                Vector2 minSpawn = SpawnCenter - SpawnRadius;
                Vector2 maxSpawn = SpawnCenter + SpawnRadius;
                enemy.transform.position = new Vector2(_r.Next((int)minSpawn.x, (int)maxSpawn.x),
                                                        _r.Next((int)minSpawn.y, (int)maxSpawn.y));
            }
        }
    }

    public void DamagePlayer(float damage) {
        CurrentHP -= damage;
        Player.GetComponent<Animator>().SetTrigger("Entity_Hit_Trigger");
    }

    private GameObject SpawnEnemy(EnemyType enemyType) {
        return Instantiate(_enemyPrefabs[(int)enemyType], _enemyParent.transform);
    }
}