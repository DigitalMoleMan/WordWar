﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update

    public float moveSpeed = 1;
    public float rollSpeed = 1;
    public float hp = 10;
    public GameObject startingWeapon;
    public GameObject activeWeapon;
    public float cooldownOnRoll;

    private float rollCooldown = 0;
    private Transform aimTowards;
    private Transform t;
    private Rigidbody2D rb2d;
    private CapsuleCollider2D cc2d;
    private Animator anim;
    AudioSource audio;
    void Start()
    {
        t = transform;
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        aimTowards = transform.Find("Crosshair");
        activeWeapon = Instantiate(startingWeapon);
        activeWeapon.transform.SetParent(transform);
        activeWeapon.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GunController activeWeaponController = activeWeapon.GetComponent<GunController>();
        Vector3 inputDir = GetInputDirection();

        rb2d.AddForce(inputDir * moveSpeed);
        

        AimTowardsTarget(aimTowards);

        AudioSource shootSound = activeWeapon.GetComponent<AudioSource>();

        if (activeWeaponController.automatic) {
            if (Input.GetButton("Fire1")) {
                activeWeaponController.Use();

                if (!shootSound.isPlaying) shootSound.Play();
            } else shootSound.Stop();
        } else if (Input.GetButtonDown("Fire1")) activeWeaponController.Use();

        if (Input.GetButtonDown("Interact")) PickUpWeapon();

        if (!cc2d.enabled && rollCooldown < 15) cc2d.enabled = true;

        anim.SetInteger("Roll Cooldown", Mathf.RoundToInt(rollCooldown));
        anim.SetFloat("Input Dir X", inputDir.x);
        anim.SetFloat("Input Dir Y", inputDir.y);
        anim.SetFloat("Velocity", rb2d.velocity.magnitude);
        if (rollCooldown <= 0) {

            if (Input.GetButtonDown("Roll") && inputDir.magnitude > 0) Roll();
        } else {
            
           
            rollCooldown--;
        }

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
        anim.Play("Roll");
        audio.Play();
        
        cc2d.enabled = false;
        rollCooldown = cooldownOnRoll;
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
