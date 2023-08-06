using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyMovement : MonoBehaviour {
    Rigidbody2D rigid;
    Animator animator;

    public int moveDir;    // Moving direction, Random
    public Transform target; //target = player

    private bool isPlayerDetected = false; // Flag to check if the player is detected

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        StartMoving();
    }

    void Update() {
        // Activate the "ismoving" animation when the player is detected and moving
        animator.SetBool("isMoving", isPlayerDetected && moveDir != 0);

        // Flip the sprite to face the direction of movement
        if (moveDir < 0) {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        } else if (moveDir > 0) {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }
    }

    void FixedUpdate() {
        rigid.velocity = new Vector2(moveDir, rigid.velocity.y);
    }

    void StartMoving() {
        InvokeRepeating("monsterAI", 0, 3); // Start calling monsterAI every 3 seconds
    }

    void monsterAI() {
        if (!isPlayerDetected) {
            moveDir = Random.Range(-1, 2); // -1<= ranNum <2
            Invoke("StopMoving", 2); // Move for 2 seconds and then stop
        }
    }

    void StopMoving() {
        moveDir = 0; // Stop moving
        Invoke("StartMoving", 1); // Wait for 1 second and then start moving again
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // find player
        if (collision.gameObject.tag == "Player") {
            isPlayerDetected = true;
            CancelInvoke("monsterAI"); // Stop random movement
            if(target.position.x > transform.position.x) {
                moveDir = 8; // speed up
            } else if (target.position.x < transform.position.x) {
                moveDir = -8;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            isPlayerDetected = false;
            CancelInvoke("StopMoving"); // Cancel the StopMoving() function if it's waiting to be invoked
            StopMoving(); // Immediately stop moving if player is not detected
        }
    }
}
