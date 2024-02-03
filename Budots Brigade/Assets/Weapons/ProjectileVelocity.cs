using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileVelocity : MonoBehaviour {
    Vector2 direction;
    float velocity;
    float timer = 1;
    float damage;
    bool isPlayerProjectile; // if false, this means its an enemy projectile

    public void SetValues(Vector2 direction, float velocity, float timer, float damage, bool isPlayerProjectile) {
        this.direction = direction;
        this.velocity = velocity;
        this.timer = timer;
        this.damage = damage;
        this.isPlayerProjectile = isPlayerProjectile;
    }
    
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.Instance.GamePaused) return;
        if (timer <= 0) Destroy(gameObject);

        // Forever Moving
        transform.position = new Vector2(transform.position.x + direction.x * velocity * Time.deltaTime,
                                        transform.position.y + direction.y * velocity * Time.deltaTime);
        timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Projectile" || col.gameObject.tag == "TriggerArea" || col.gameObject.tag == "Pickup") return;

        // Debug.Log("hit " + col.gameObject.name + " , " + col.gameObject.tag);

        if (isPlayerProjectile) {
            if (col.gameObject.tag == "Player") return;

            if (col.gameObject.tag == "Enemy") {
                col.gameObject.GetComponent<EnemyEntity>().Damage(damage);
            }
            
            Destroy(gameObject);
        } else {
            if (col.gameObject.tag == "Enemy") return;
            GameManager.Instance.DamagePlayer(damage);
            Destroy(gameObject); 
        }
    }
}
