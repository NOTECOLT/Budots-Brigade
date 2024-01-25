using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundParent : MonoBehaviour {
    public Camera cam;
    public float distanceScale = 1.0f;
    private Vector2 _parent;
    void Start() {
        _parent = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }


    void Update() {
        Vector2 mousePos = Input.mousePosition;
        
        if (transform.parent != null)
            _parent = cam.WorldToScreenPoint(transform.parent.transform.position);

        transform.localPosition = new Vector2(mousePos.x - _parent.x, mousePos.y - _parent.y).normalized * distanceScale;
    }
}
