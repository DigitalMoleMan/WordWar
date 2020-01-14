using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeController : WeaponController {
    public string name;
    public float damage;
    public float fireRate;
    public bool automatic;


    Transform visuals;
    Animator anim;

    float cooldown = 0;

    // Start is called before the first frame update
    void Start() {
        visuals = transform.Find("Visuals");
        anim = visuals.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (cooldown > 0) cooldown -= fireRate;
    }

    public void Use() {
            if (cooldown <= 0) {
                anim.Play("Swing");

                cooldown = 100;
            }
    }
}
