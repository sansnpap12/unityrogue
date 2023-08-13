using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicianenemyhitbox : MonoBehaviour
{

    private MagicianEnemyHealth magicianenemyhealth;
    public Animator animator;
    private bool isPlayerAttacking = false;

    void Start()
    {  
        magicianenemyhealth = FindObjectOfType<MagicianEnemyHealth>();
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

            StartCoroutine(magicianenemyhealth.DecreaseHealthByAmount(10f));

        }

        animator.SetBool("enableAttack", false);
        isPlayerAttacking = false; 
    }

}
