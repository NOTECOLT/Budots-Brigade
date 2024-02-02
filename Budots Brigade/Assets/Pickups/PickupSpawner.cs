using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PickupSpawner : MonoBehaviour {
    [SerializeField] private GameObject _pickupParent;
    [SerializeField] private GameObject _pickupObj;
    [SerializeField] private Vector2 _spawnCenter = Vector2.zero;
    [SerializeField] private Vector2 _spawnRadius;
    [SerializeField] private float _spawnTimer;
    private float _timer = 0f;
    [SerializeField] private int _pickupLimit;  // maximum number of pickups on the floor
    private System.Random _r;


    [SerializeField] private float _powerupChance = 0.25f;
    [SerializeField] private float[] _weaponChances;
    [SerializeField] private Weapon[] _weapons;
    
    void Start() {
        _r = new System.Random();
        SpawnPickups(_pickupLimit);
    }

    void Update() {
        if (_timer <= 0f) {
            _timer = _spawnTimer;

            if (_pickupParent.transform.childCount < _pickupLimit) 
                SpawnPickups(_pickupLimit - _pickupParent.transform.childCount);
        }

        _timer -= Time.deltaTime;
    }

    private void SpawnPickups(int number) {
        int maxChance = 100;

        for (int i = 0; i < number; i++) {
            GameObject p = Instantiate(_pickupObj, _pickupParent.transform);
            Vector2 minSpawn = _spawnCenter - _spawnRadius;
            Vector2 maxSpawn = _spawnCenter + _spawnRadius;
            p.transform.position = new Vector2(_r.Next((int)minSpawn.x, (int)maxSpawn.x),
                                                    _r.Next((int)minSpawn.y, (int)maxSpawn.y));

            int roll = _r.Next(0, maxChance);
            int minChance = 0;
            for (int j = 0; j < _weapons.Length; j++) {
                if (roll >= minChance && roll < minChance + _weaponChances[j] * maxChance) {
                    Debug.Log("Spawning " + _weapons[j].name);
                    p.AddComponent<WeaponPickup>();
                    p.GetComponent<WeaponPickup>().SetWeapon(_weapons[j]);
                    break;
                }

                minChance = minChance + (int)(_weaponChances[j] * maxChance);
            }
        }

        // Spawn a Powerup 
        if (_r.Next(0, maxChance) < _powerupChance * maxChance) {
            Debug.Log("Spawning Powerup");
            GameObject p = Instantiate(_pickupObj, _pickupParent.transform);
            Vector2 minSpawn = _spawnCenter - _spawnRadius;
            Vector2 maxSpawn = _spawnCenter + _spawnRadius;
            p.transform.position = new Vector2(_r.Next((int)minSpawn.x, (int)maxSpawn.x),
                                                    _r.Next((int)minSpawn.y, (int)maxSpawn.y));
            p.AddComponent<PowerUpCoin>();
            p.GetComponent<PowerUpCoin>().SetType(modifiableStat.WALK_SPEED, 1.5f);
        }
    }
}
