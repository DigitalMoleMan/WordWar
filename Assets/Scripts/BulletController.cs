using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public string firedBy;
    public float damage = 1;
    public float velocity = 1;

    GameObject trail;

    private int lifetime = 500;
    void Start() {
        trail = GameObject.Find("Trail");

    }

    // Update is called once per frame
    void Update() {
        lifetime--;

        if (lifetime <= 0) RemoveBullet();

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != firedBy) {
            if (collision.gameObject.tag == "Enemy") collision.gameObject.GetComponent<EnemyController>().Damage(damage);
            if (collision.gameObject.tag == "Player") collision.gameObject.GetComponent<PlayerController>().Damage(damage);
            RemoveBullet();
        }
    }

    private void RemoveBullet() {
       // MakeTrailIndependentAndDestroy();
       /// gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void MakeTrailIndependentAndDestroy() {
        trail.transform.SetParent(transform.parent);

        Destroy(trail, trail.GetComponent<TrailRenderer>().time);
    }
}
