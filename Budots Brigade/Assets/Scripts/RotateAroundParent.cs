using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundParent : MonoBehaviour {
    public Camera cam;
    public float distanceScale = 1.0f;
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

        transform.localPosition = (mousePos - _rayOrigin).normalized * distanceScale;
    }
}
