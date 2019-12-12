using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifetime;
    public Vector3 velocity;

    ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update(){

        UpdatePosition();
        
        
            
            
    }

    void UpdatePosition() {
        transform.position += velocity;
    }
}
