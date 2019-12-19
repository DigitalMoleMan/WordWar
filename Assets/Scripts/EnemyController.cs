using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : HpController {
    public float moveSpeed = 5;
    public float visionRadius = 10;
    public GameObject equippedWeapon;

    private Rigidbody2D rb2d;
    private GameObject currentTarget;
    private GameObject activeWeapon;
    private bool targetInRange = false;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        currentTarget = GameObject.Find("Player");

        activeWeapon = Instantiate(equippedWeapon) as GameObject;
        activeWeapon.transform.SetParent(transform);
        activeWeapon.transform.position = transform.position;


    }

    void Update() {

        float distanceFromTarget = (currentTarget.transform.position - transform.position).magnitude;

        if (distanceFromTarget < visionRadius) targetInRange = true;
        else targetInRange = false;

        if (targetInRange) {
            MoveTowardsTarget();
            AimTowardsTarget(currentTarget.transform);
            activeWeapon.GetComponent<GunController>().Shoot();
        }

        if (hp <= 0) Die();
    }



    void MoveTowardsTarget() {
        Vector3 targetDir = (currentTarget.transform.position - transform.position).normalized;
        rb2d.AddForce(targetDir * moveSpeed);
    }

    void AimTowardsTarget(Transform target) {
        Vector3 offset_pos = target.position - activeWeapon.transform.position;

        activeWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(offset_pos.y, offset_pos.x) * Mathf.Rad2Deg));
    }

    

    void Die() {
        activeWeapon.transform.SetParent(GameObject.Find("WorldDrops").transform);
        Destroy(gameObject);
    }
}
