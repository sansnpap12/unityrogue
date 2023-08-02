using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    int movementFlag = 0;
    float t1, t2; // 't1'과 't2'를 여기서 선언합니다.
    float breaktime = 2f;
    public Transform target; // 특정 오브젝트의 Transform

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()
    {
        while (true) // 무한 반복하여 코루틴을 유지합니다.
        {
            movementFlag = Random.Range(0, 4);

            if (movementFlag == 0 || movementFlag == 3)
            {
                animator.SetBool("isMoving", false);
                rb.velocity = Vector2.zero;
                yield return new WaitForSeconds(breaktime); // 0 또는 3일 때 2초의 휴식을 줍니다.
            }
            else if (movementFlag == 1)
            {
                animator.SetBool("isMoving", true);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                t1 = Time.time;
                while (Time.time - t1 <= breaktime)
                {
                    rb.velocity = new Vector2(-1, rb.velocity.y);
                    yield return null;
                }
                rb.velocity = Vector2.zero; // 2초가 지난 후 움직임을 멈춥니다.
            }
            else if (movementFlag == 2)
            {      
                animator.SetBool("isMoving", true);
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                t2 = Time.time;
                while (Time.time - t2 <= breaktime)
                {
                    rb.velocity = new Vector2(1, rb.velocity.y);
                    yield return null;
                }
                rb.velocity = Vector2.zero; // 2초가 지난 후 움직임을 멈춥니다.
            }
        }
    }

    void Update()
    {   
      
    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("attack");
        }


        
    }
}









