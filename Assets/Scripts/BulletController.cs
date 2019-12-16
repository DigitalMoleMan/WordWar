using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public int damage = 1;

    ParticleSystem ps;
    void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyController>().Damage(damage);
            
        }

        Destroy(gameObject);
    }
}
