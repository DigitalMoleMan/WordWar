using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullets;
    public float bulletVelocity;
    public float fireRate;

    Animator anim;

    float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.Find("Visuals").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) cooldown -= fireRate;
    }

    public void Shoot() {
        
        if (cooldown <= 0) {
            anim.Play("Shooting");
            GameObject firedBullet = Instantiate(bullets) as GameObject;

            firedBullet.transform.SetParent(GameObject.Find("WorldProjectiles").transform);

            firedBullet.transform.rotation = transform.rotation;
            firedBullet.transform.position = transform.position + firedBullet.transform.right;

            Rigidbody2D bulletRb2d = firedBullet.GetComponent<Rigidbody2D>();

            firedBullet.GetComponent<BulletController>().firedBy = transform.parent.tag;

            bulletRb2d.AddForce(firedBullet.transform.right * bulletVelocity);

            cooldown = 100;
        }
    }
}
