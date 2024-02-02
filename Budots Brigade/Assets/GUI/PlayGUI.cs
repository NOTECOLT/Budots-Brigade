using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayGUI : MonoBehaviour
{
    [SerializeField] public PlayerStats player;

    [SerializeField] public TextMeshProUGUI health;
    [SerializeField] public TextMeshProUGUI speed;
    [SerializeField] public TextMeshProUGUI damage;

    // Start is called before the first frame update
    void Start()
    {
        health.text = GameManager.Instance.PlayerHP.ToString("");
        speed.text = player.mod_walkSpeed.ToString("");
        damage.text = player.mod_damBonus.ToString("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
