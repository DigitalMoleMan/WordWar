using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    // Start is called before the first frame update

    public float moveSpeed = 1;

    
    void Start()
    {
        
}

    // Update is called once per frame
    void Update()
    {
        Transform t = GetComponent<Transform>();
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(GetInputDirection() * moveSpeed);


       if (Input.GetButton("Fire1")) {
            Debug.Log("Fire!");

        }
    }

    Vector3 GetInputDirection() {
        Vector3 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        return inputDir;
    }
}
