using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagician : MonoBehaviour
{
    public GameObject waterbulletPrefab;
    public float attackRate = 2f;
    private Transform target;
    private float timeAfterAttack;

    void Start()
    {
        timeAfterAttack = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterAttack += Time.deltaTime;

        if(timeAfterAttack >= attackRate)
        {
            timeAfterAttack = 0f;

            GameObject waterbullet = Instantiate(waterbulletPrefab, transform.position, transform.rotation);
        }
    }
}
