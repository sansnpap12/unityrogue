using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortenemyhitbox : MonoBehaviour
{
   
    public int health = 5;
    public Animator animator;
    private bool isPlayerAttacking = false;

    void Start()
    {
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
            health -= 1;
            Debug.Log(health);
        }

        animator.SetBool("enableAttack", false);
        isPlayerAttacking = false; 
    }

}
