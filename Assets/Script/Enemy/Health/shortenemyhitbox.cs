using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortenemyhitbox : MonoBehaviour
{

    private ShortEnemyHealth shortenemyhealth;
    public Animator animator;
    private bool isPlayerAttacking = false;

    void Start()
    {  
        shortenemyhealth = FindObjectOfType<ShortEnemyHealth>();
        animator = GetComponent<Animator>();
        animator.SetBool("enableAttack", false);
    }

    // Update is called once per frame
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isPlayerAttacking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Weapon") && isPlayerAttacking)
        {

            StartCoroutine(shortenemyhealth.DecreaseHealthByAmount(10f));

        }

        animator.SetBool("enableAttack", false);
        isPlayerAttacking = false; 
    }

}
