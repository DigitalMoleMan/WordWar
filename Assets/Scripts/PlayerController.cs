using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update

    public float moveSpeed = 1;

    public int healthPoints = 10;

    public Transform aimTowards;

    public Object bullet;

    public float bulletSpeed = 1;

    public int fireRate = 1;

    private int weaponCooldown = 0;

    private Transform t;
    private Rigidbody2D rb2d;
    void Start()
    {
        t = transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(GetInputDirection() * moveSpeed);


        if (Input.GetButton("Fire1") && weaponCooldown == 0) FireBullet();

        if (weaponCooldown > 0) weaponCooldown -= fireRate;
    }

    void FireBullet() {

        Vector3 aimDirection = (aimTowards.position - t.position).normalized;
        
        GameObject firedBullet = Instantiate(bullet) as GameObject;


        firedBullet.transform.position = t.position + aimDirection;

       
        firedBullet.transform.Rotate(0, 0, Vector3.Angle(t.position, aimTowards.position));
        
        Rigidbody2D bulletRb2d = firedBullet.GetComponent<Rigidbody2D>();
        //BulletController bulletController = firedBullet.GetComponent<BulletController>();

        bulletRb2d.AddForce(aimDirection * bulletSpeed);

        weaponCooldown = 100;
    }

    Vector3 GetInputDirection() {
        Vector3 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        return inputDir;
    }
}
