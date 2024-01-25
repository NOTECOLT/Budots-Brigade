using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class PointToMouse : MonoBehaviour {
    public Camera cam;
    public float angleOffset;
    private Vector2 _parent;
    void Start() {
        _parent = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }


    void Update() {
        Vector2 mousePos = Input.mousePosition;
        if (transform.parent != null)
            _parent = cam.WorldToScreenPoint(transform.parent.transform.position);

        float angle = Mathf.Atan2(mousePos.y - _parent.y, mousePos.x - _parent.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
    }
}
