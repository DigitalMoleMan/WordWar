using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour {
    public float mouseSpeed = 1;
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        Transform t = GetComponent<Transform>();
        t.position += GetMouseMovement() * mouseSpeed;
    }

    Vector3 GetMouseMovement() {
        return new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
    }
}
