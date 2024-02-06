using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Pistol", menuName = "Weapon/Pistol", order = 1)]
public class Pistol : Weapon {
    public GameObject Trail;
    public override int DoAttack(GameObject obj, Vector2 mousePos) {
        Debug.DrawRay(obj.transform.position,  mousePos - (Vector2)obj.transform.position, Color.red);
        
        if (!Input.GetMouseButtonUp((int)MouseButton.Left)) return 0;
        
        GameObject hs = Instantiate(Trail, obj.transform.position, Quaternion.identity);
        hs.GetComponent<HitscanTrail>().SetValues(obj.transform.position, mousePos);
        Debug.Log(hs.name);

        // Casts a ray from the center of the player
        RaycastHit2D hit = Physics2D.Raycast(obj.transform.position, mousePos - (Vector2)obj.transform.position, 200, LayerMask.GetMask("Attackable")); // 3 is Attackable layer mask

        if (hit) {
            Debug.Log("HIT " + hit.collider.name + " using Pistol.");
            if (hit.collider.gameObject.tag == "Enemy") {
                hit.collider.gameObject.GetComponent<EnemyEntity>().Damage(Damage);
            }
        }

        System.Random random = new System.Random();

        GunSFX gunSFX = obj.GetComponentInChildren<GunSFX>();
        gunSFX.PlayClip(SFX[random.Next(SFX.Length)]);

        return 1;
    }
}
