using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update

    public float moveSpeed = 1;

    public float hp = 10;
    public Transform aimTowards;
    public GameObject startingWeapon;

    private GameObject activeWeapon;
    private Transform t;
    private Rigidbody2D rb2d;
    void Start()
    {
        t = transform;
        rb2d = GetComponent<Rigidbody2D>();

        activeWeapon = Instantiate(startingWeapon);
        activeWeapon.transform.SetParent(transform);
        activeWeapon.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(GetInputDirection() * moveSpeed);

        AimTowardsTarget(aimTowards);

        if (Input.GetButton("Fire1")) activeWeapon.GetComponent<GunController>().Shoot();

        if (Input.GetButton("Fire2")) {
            GameObject drops = GameObject.Find("WorldDrops");

            foreach (Transform drop in drops.transform) {
                
                if((drop.position - t.position).magnitude < 2) {

                    activeWeapon.transform.SetParent(drops.transform);
                    activeWeapon = drop.gameObject;
                    activeWeapon.transform.SetParent(t);
                    activeWeapon.transform.position = t.position;
                }
                
            }
        }

        if (hp <= 0) Die();
    }

    public void Damage(float dmg) {
        hp -= dmg;
    }

    void Die() {
        Destroy(gameObject);
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
