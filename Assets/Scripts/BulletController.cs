using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int lifetime;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
}

    // Update is called once per frame
    void Update()
    {
        Transform t = GetComponent<Transform>();

        t.position += velocity;
        if (lifetime < 0)
        {
            ParticleSystem ps = GetComponent<ParticleSystem>();
            ps.Play();
            Destroy(gameObject);
        }
        else lifetime--;
    }
}
