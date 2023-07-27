using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    private Rigidbody2D waterbulletRigidbody;
    Transform playerPos;
    Vector2 dir;
    private float speed = 300f; // Adjust this value as needed

    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();

        // Set y component of the direction vector to 0
        dir = new Vector2(playerPos.position.x - transform.position.x, 0f).normalized;

        GetComponent<Rigidbody2D>().AddForce(dir * speed);

        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
