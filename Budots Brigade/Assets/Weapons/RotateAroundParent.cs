using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundParent : MonoBehaviour {
    public Camera cam;
    public float distanceScale = 1.0f;
    private Vector2 _parent;

    private Vector2 velocity = Vector2.zero;
    public float smoothTime = 0.3f;
    

    // public SpriteRenderer sprite;
    void Start() {
        _parent = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }


    void Update() {
        if (GameManager.Instance.GamePaused) return;
        Vector2 mousePos = Input.mousePosition;
        
        if (transform.parent != null)
            _parent = cam.WorldToScreenPoint(transform.parent.transform.position);
            Vector2 offset = transform.parent.transform.position - transform.position;
            // sprite.flipY = offset.x < 0;

        Vector2 newPos = new Vector2(mousePos.x - _parent.x, mousePos.y - _parent.y).normalized * distanceScale;
        transform.localPosition = Vector2.SmoothDamp(transform.localPosition, newPos, ref velocity, smoothTime);
    }
}
