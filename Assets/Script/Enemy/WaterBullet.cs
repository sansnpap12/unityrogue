using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    private Rigidbody2D waterbulletRigidbody;
    Transform playerPos;
    Vector2 dir;

    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        dir = playerPos.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir.normalized * Time.deltaTime * 1000000);
        
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
