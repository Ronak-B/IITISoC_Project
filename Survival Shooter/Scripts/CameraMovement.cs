using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    Vector3 offset;
    public float smoothing = 5f;
    private void Start()
    {
        offset = transform.position - target.position;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,target.position+offset, smoothing * Time.deltaTime);
    }

}
