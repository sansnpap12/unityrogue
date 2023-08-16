using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public Collider2D weaponCollider;
    
    void Start()
    {
        weaponCollider = GetComponent<Collider2D>();
        weaponCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(EnableColliderForOneSecond());
            
        }
    }

    private IEnumerator EnableColliderForOneSecond()
    {
        weaponCollider.enabled = true;

        yield return new WaitForSeconds(0.1f);

        weaponCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy HitBox")
        {
            // Handle collision with enemy hitbox if needed.
        }
    }
}
