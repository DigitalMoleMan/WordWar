using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public string name;
    public GameObject bullets;
    public float bulletVelocity;
    public float fireRate;
    public bool automatic;
    public int ammo;
    public int maxAmmo;


    Transform visuals;
    Animator anim;

    float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        visuals = transform.Find("Visuals");
        anim = visuals.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) cooldown -= fireRate;
    }

    public void Shoot() {
        if(ammo > 0) { 
        if (cooldown <= 0) {
            anim.Play("Shooting");
            GameObject firedBullet = Instantiate(bullets) as GameObject;

            firedBullet.transform.SetParent(GameObject.Find("WorldProjectiles").transform);

            firedBullet.transform.rotation = transform.rotation;
            firedBullet.transform.position = transform.position + firedBullet.transform.right;

            Rigidbody2D bulletRb2d = firedBullet.GetComponent<Rigidbody2D>();

            firedBullet.GetComponent<BulletController>().firedBy = transform.parent.tag;
                if (transform.parent.tag == "Player") ammo--;

            bulletRb2d.AddForce(firedBullet.transform.right * bulletVelocity);

            cooldown = 100;
        }
        }
    }
}
