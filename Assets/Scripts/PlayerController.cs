using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update

    public float moveSpeed = 1;

    public int healthPoints = 10;

    public GameObject hands;

    public Transform aimTowards;

    public Object bullet;

    private Transform t;
    private Rigidbody2D rb2d;
    void Start()
    {
        t = transform;
        rb2d = GetComponent<Rigidbody2D>();
        hands = t.Find("Hands").gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(GetInputDirection() * moveSpeed);

        UpdateHandRotation();

        if (Input.GetButton("Fire1")) hands.GetComponentInChildren<GunController>().Shoot();
    }

    void UpdateHandRotation() {
        Vector3 offset_pos = aimTowards.position - hands.transform.position;

        hands.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(offset_pos.y, offset_pos.x) * Mathf.Rad2Deg));
    }

    Vector3 GetInputDirection() {
        Vector3 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        return inputDir;
    }
}
