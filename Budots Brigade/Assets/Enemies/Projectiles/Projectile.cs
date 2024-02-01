using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDir;
    float moveSpeed = 5f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDestruct());
    }

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hit");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER RANGE HIT");
        }
    }
}
