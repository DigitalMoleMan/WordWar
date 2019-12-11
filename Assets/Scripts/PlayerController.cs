using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update

    public float moveSpeed = 1;

    public Transform aimTowards;

    public Object bullet;

    public int fireRate = 1;

    private int weaponCooldown = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = GetComponent<Transform>();
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(GetInputDirection() * moveSpeed);


       if (Input.GetButton("Fire1") && (weaponCooldown == 0)) {

            weaponCooldown = 100;
            GameObject firedBullet = Instantiate(bullet) as GameObject;

            Vector3 aimDirection = (aimTowards.position - t.position).normalized;
            firedBullet.transform.position = t.position + aimDirection;

            
            //firedBullet.transform.rotation = Quaternion.LookRotation(aimDirection, Vector3.up);
            firedBullet.GetComponent<BulletController>().velocity = aimDirection / 4;
        }

        if (weaponCooldown > 0) weaponCooldown -= fireRate;
    }

    Vector3 GetInputDirection() {
        Vector3 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        return inputDir;
    }
}
