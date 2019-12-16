using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 1;
    public float moveSpeed = 5;
    public GameObject currentTarget;

   
    private Rigidbody2D rb2d;
    private GameObject hands;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hands = transform.Find("Hands").gameObject;
    }

    void Update()
    {
        MoveTowardsTarget();

        UpdateHandRotation();
    }

    void UpdateHandRotation() {
        Vector3 offset_pos = currentTarget.transform.position - hands.transform.position;

        hands.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(offset_pos.y, offset_pos.x) * Mathf.Rad2Deg));
    }

    public void Damage(int dmg) {
        if (hp >= 0) hp -= dmg;
        else Die();
    }

    void MoveTowardsTarget() {
        Vector3 targetDir = (currentTarget.transform.position - transform.position).normalized;
        rb2d.AddForce(targetDir * moveSpeed);
    }

    void Die() {
        Debug.Log("I died");
        Destroy(gameObject);
    }
}
