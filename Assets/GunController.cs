using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public GameObject bullets;

    public float bulletVelocity = 10;

    public float fireRate = 1;

    public Animator anim;

    private float cooldown = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) cooldown -= fireRate;
        float c = cooldown;
        anim.SetFloat("Cooldown", c);
    }

    public void Shoot() {
        Debug.Log("shuut");
        if (cooldown < 0) {
            GameObject firedBullet = Instantiate(bullets) as GameObject;

            firedBullet.transform.rotation = transform.rotation;
            firedBullet.transform.position = transform.position + firedBullet.transform.right;

            Rigidbody2D bulletRb2d = firedBullet.GetComponent<Rigidbody2D>();
            bulletRb2d.AddForce(firedBullet.transform.right * bulletVelocity);

            cooldown = 100;
        }
    }
}
