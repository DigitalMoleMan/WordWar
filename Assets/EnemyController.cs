using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int startingHp = 10;
    public float moveSpeed = 5;
    public GameObject currentTarget;

    private int hp;
    private Rigidbody2D rb2d;
    
    void Start()
    {
        hp = startingHp;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveTowardsTarget();

        if (hp < 0) Die();
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("hey");
    }

    void MoveTowardsTarget() {
        Vector3 targetDir = (currentTarget.transform.position - transform.position).normalized;
        rb2d.AddForce(targetDir * moveSpeed);
    }

    void Die() {
        Destroy(gameObject);
    }
}
