using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyMovement : MonoBehaviour {
    Rigidbody2D rigid;
    public int moveDir;    // Moving direction, Random
    public Transform target; //target = player

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        monsterAI();
    }

    void Update() {
    }

    void FixedUpdate() {
        rigid.velocity = new Vector2(moveDir, rigid.velocity.y);
    }

    void monsterAI() {
        moveDir = Random.Range(-1, 2);   // -1<= ranNum <2
        Invoke("monsterAI", 3);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // find player
        if (collision.gameObject.tag == "Player") {
            CancelInvoke("monsterAI");   // 이 부분에서 함수를 바로 취소하지 못해 왔다갔다 하면 딜레이가 조금 있다.
            if(target.position.x > transform.position.x) {
                moveDir = 8;     // speed up
            } else if (target.position.x < transform.position.x) {
                moveDir = -8;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
            monsterAI();    // return to normal
    }

}