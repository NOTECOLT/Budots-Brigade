using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeCheck : MonoBehaviour
{
    public GameObject PlayerTarget {get; set;}
    private EnemyEntity _enemy;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponentInParent<EnemyEntity>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _enemy.SetStrikingDistanceBool(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _enemy.SetStrikingDistanceBool(false);
        }
    }
}
