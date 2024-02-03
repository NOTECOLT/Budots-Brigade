using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HitscanTrail : MonoBehaviour {
    private Vector2 _startVec;
    private Vector2 _direction;
    private float _progress;
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        _progress += Time.deltaTime * _speed;
        transform.position = Vector3.Lerp(_startVec, _direction, _progress);
    }
    public void SetValues(Vector2 start, Vector2 direction) {
        Debug.Log("HITSCAN " + start + " -> " + direction);
        _startVec = start;
        _direction = direction;
    }
}
