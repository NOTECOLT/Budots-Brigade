using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Pistol", menuName = "Weapon/Pistol", order = 1)]
public class Pistol : Weapon {
    public override int DoAttack(GameObject obj, Vector2 mousePos) {
        Debug.DrawRay(obj.transform.position,  mousePos - (Vector2)obj.transform.position, Color.red);
        
        if (!Input.GetMouseButtonUp((int)MouseButton.Left)) return 0;
        
        // Casts a ray from the center of the player
        RaycastHit2D hit = Physics2D.Raycast(obj.transform.position, mousePos - (Vector2)obj.transform.position, 100);

        if (hit.collider != null) {
            Debug.Log("HIT " + hit.collider.name + " using Pistol.");
        }

        return 0;
    }
}
