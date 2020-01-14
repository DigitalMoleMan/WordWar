using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : HpController {


    public float moveSpeed = 5;
    public float visionRadius = 10;
    public GameObject equippedWeapon;


    protected Rigidbody2D rb2d;
    protected GameObject currentTarget;
    protected GameObject activeWeapon;

    protected bool targetInRange = false;

    protected CapsuleCollider2D navCollider;

    void Start() {
        
        rb2d = GetComponent<Rigidbody2D>();
        currentTarget = GameObject.Find("Player");

       

        navCollider = GameObject.Find("NavBox").GetComponent<CapsuleCollider2D>();

        activeWeapon = Instantiate(equippedWeapon) as GameObject;
        activeWeapon.transform.SetParent(transform);
        activeWeapon.transform.position = transform.position;

        TypeStart();
    }

   

    public virtual void TypeStart() {
        
    }

    void Update() {
        TypeUpdate();
        if (hp <= 0) Die();
    }

    public virtual void TypeUpdate() {

    }

    void OnTriggerEnter2D() {

    }

    protected void MoveTowardsTarget() {
        Vector3 targetDir = (currentTarget.transform.position - transform.position).normalized;
        rb2d.AddForce((targetDir * moveSpeed) * (Time.deltaTime * 60));
    }


    protected void AimTowardsTarget(Transform target) {
        Vector3 offset_pos = target.position - activeWeapon.transform.position;

        activeWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(offset_pos.y, offset_pos.x) * Mathf.Rad2Deg));
    }

    

    void Die() {
        activeWeapon.transform.SetParent(GameObject.Find("WorldDrops").transform);
        Destroy(gameObject);
    }
}
