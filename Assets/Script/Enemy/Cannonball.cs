using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private Rigidbody2D waterbulletRigidbody;
    Vector2 dir;
    private float speed = 300f;

    void Start()
    {
        dir = new Vector2(-1f, 0f);

        GetComponent<Rigidbody2D>().AddForce(dir * speed);

        Destroy(gameObject, 2f);
    }

    void Update()
    {
        
    }
}
