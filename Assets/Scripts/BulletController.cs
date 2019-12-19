using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public string firedBy;
    public float damage = 1;

    ParticleSystem ps;

    private int lifetime = 500;
    void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        lifetime--;

        if(lifetime <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != firedBy) {
            if (collision.gameObject.tag == "Enemy") collision.gameObject.GetComponent<EnemyController>().Damage(damage);

            if (collision.gameObject.tag == "Player") collision.gameObject.GetComponent<PlayerController>().Damage(damage);
            if (collision.gameObject.tag != "Projectile") Destroy(gameObject);
        }

    }
}
