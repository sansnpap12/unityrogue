using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttack : MonoBehaviour
{
    public GameObject CannonballPrefab;
    public float attackRate = 1.5f;
    private Transform target;
    private float timeAfterAttack;

    void Start()
    {
        timeAfterAttack = 0f;
    }

    void Update()
    {
        timeAfterAttack += Time.deltaTime;

        if(timeAfterAttack >= attackRate)
        {
            timeAfterAttack = 0f;

            GameObject Cannonball = Instantiate(CannonballPrefab, transform.position, transform.rotation);
        }
    }
}