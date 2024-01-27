using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVelocity : MonoBehaviour {
    Vector2 direction;
    float velocity;
    float timer;

    public void SetValues(Vector2 direction, float velocity, float timer) {
        this.direction = direction;
        this.velocity = velocity;
        this.timer = timer;
    }
    
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (timer <= 0) Destroy(gameObject);

        // Forever Moving
        transform.position = new Vector3(transform.position.x + direction.x * velocity * Time.deltaTime,
                                        transform.position.y + direction.y * velocity * Time.deltaTime, 0);
        timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag != "Projectile") {
            Destroy(gameObject);
        }
        
    }
}
