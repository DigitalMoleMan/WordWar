using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update

    public float moveSpeed = 1;
    public float rollSpeed = 1;
    public float hp = 10;
    public GameObject startingWeapon;
    public GameObject activeWeapon;

    private int rollCooldown = 0;
    private Transform aimTowards;
    private Transform t;
    private Rigidbody2D rb2d;
    private CapsuleCollider2D cc2d;
    private Animator anim;
    void Start()
    {
        t = transform;
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        aimTowards = transform.Find("Crosshair");
        activeWeapon = Instantiate(startingWeapon);
        activeWeapon.transform.SetParent(transform);
        activeWeapon.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GunController activeWeaponController = activeWeapon.GetComponent<GunController>();


        rb2d.AddForce(GetInputDirection() * moveSpeed);
        

        AimTowardsTarget(aimTowards);
        if (activeWeaponController.automatic && Input.GetButton("Fire1")) activeWeaponController.Shoot();
        else if (Input.GetButtonDown("Fire1")) activeWeaponController.Shoot();

        if (Input.GetButtonDown("Interact")) PickUpWeapon();

        if (!cc2d.enabled && rollCooldown < 15) cc2d.enabled = true;

        if (rollCooldown <= 0) {
            
            if (Input.GetButtonDown("Roll") && GetInputDirection().magnitude > 0) Roll();
        } else rollCooldown--;

        if (hp <= 0) Die();
    }

    void PickUpWeapon() {
        GameObject drops = GameObject.Find("WorldDrops");

        foreach (Transform drop in drops.transform) {

            if ((drop.position - t.position).magnitude < 2) {

                activeWeapon.transform.SetParent(drops.transform);
                activeWeapon = drop.gameObject;
                activeWeapon.transform.SetParent(t);
                activeWeapon.transform.position = t.position;
            }

        }
    }
    
    void Roll() {
        rb2d.AddForce(GetInputDirection() * rollSpeed);
        anim.Play("Player_Roll");
        cc2d.enabled = false;
        rollCooldown = 40;
    }
    public void Damage(float dmg) {
        hp -= dmg;
    }

    void Die() {
        gameObject.SetActive(false);
    }

    void AimTowardsTarget(Transform target) {
        Vector3 offset_pos = target.position - activeWeapon.transform.position;
        activeWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(offset_pos.y, offset_pos.x) * Mathf.Rad2Deg));
    }

    Vector3 GetInputDirection() {
        Vector3 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        return inputDir;
    }
}
