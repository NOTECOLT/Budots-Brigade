using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class PointToMouse : MonoBehaviour {
    public Camera cam;
    public float angleOffset;
    private Vector2 _rayOrigin;
    void Start() {
        _rayOrigin = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }


    void Update() {
        Vector2 mousePos = Input.mousePosition;

        // If the transform has no parent, the vector to the cursor will point from the center of the screen
        //      Else, the vector will point from the parent object.
        if (transform.parent != null)
            _rayOrigin = cam.WorldToScreenPoint(transform.parent.transform.position);

        float angle = Mathf.Atan2(mousePos.y - _rayOrigin.y, mousePos.x - _rayOrigin.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
    }
}
