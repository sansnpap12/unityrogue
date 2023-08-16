using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseenemyhitbox : MonoBehaviour
{

    private ChaseEnemyHealth chaseenemyhealth;
    public Animator animator;
    private bool isPlayerAttacking = false;
        private float attackCooldown = 0.5f;
    private float lastAttackTime;

    void Start()
    {  
        chaseenemyhealth = FindObjectOfType<ChaseEnemyHealth>();
        animator = GetComponent<Animator>();
        animator.SetBool("enableAttack", false);
    }

    // Update is called once per frame
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.time - lastAttackTime > attackCooldown)
        {
            isPlayerAttacking = true;
            lastAttackTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Weapon") && isPlayerAttacking)
        {

            StartCoroutine(chaseenemyhealth.DecreaseHealthByAmount(10f));

        }

        animator.SetBool("enableAttack", false);
        isPlayerAttacking = false; 
    }

}
