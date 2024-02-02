using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag != "Player") return;

        Destroy(gameObject);
    }
}
