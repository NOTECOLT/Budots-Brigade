using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerUpCoin : MonoBehaviour
{
    [SerializeField] public float timeout = 1f;
    [SerializeField] public Transform t;
    public string pup_type;
    public float amount;


    void Start()
    {
        Invoke("Despawn", timeout);
    }

    public void Despawn(){
        CancelInvoke();
        t.position = new Vector2(1000,1000);
        //Destroy(this);
    }
}
