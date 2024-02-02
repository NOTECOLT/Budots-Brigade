using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Connect;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Weapon/Shotgun", order = 2)]
public class Shotgun : Weapon {
    public GameObject Projectile;
    public float ProjectileVelocity;
    public float Spray; // How wide in degrees each projectile is from each other

    public override int DoAttack(GameObject obj, Vector2 mousePos) {
        Debug.DrawRay(obj.transform.position,  mousePos - (Vector2)obj.transform.position, Color.yellow);
        
        if (!Input.GetMouseButtonUp((int)MouseButton.Left)) return 0;
        
        // Spawns 3 Projectiles at the barrel of the gun whose velocity are of equal angle away from each other
        IEnumerable<GameObject> projectiles = Enumerable.Range(0, 3).Select(_ => Instantiate(Projectile, obj.transform));
        float angle = Mathf.Atan2(mousePos.y - obj.transform.position.y, mousePos.x - obj.transform.position.x) * Mathf.Rad2Deg - Spray;

        foreach (GameObject p in projectiles) {
            p.transform.localPosition = (mousePos - (Vector2)obj.transform.position).normalized;
            p.transform.parent = null;

            ProjectileVelocity pv = p.GetComponent<ProjectileVelocity>();

            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            pv.SetValues(direction, ProjectileVelocity, 1.0f, Damage, true);

            angle += Spray;
        }

        System.Random random = new System.Random();

        if (SFX.Length > 0)
            SFXManager.Instance.PlayClip(SFX[random.Next(SFX.Length)]);

        return 1;
    }
}
