using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private float defaultspeed = 5f;
    public float speed; // 이동 속도

    public Animator animator;
    public Rigidbody2D rb;
    private int jumpcount = 0;

    private bool isdash;
    private float dashspeed = 40f;
    private float defaulttime = 0.1f;
    private float dashtime;

    public float enemydamage = 5f;
    public float cannondamage = 5f;

    public BoxCollider2D PlayerCollider;

    private HealthManager hm;
    private CannonAttack ca;

    private bool canmove = true;

    float t1;


    public TrailRenderer trailRenderer; // Trail Renderer 컴포넌트를 참조할 변수

    void Start()
    {   

        PlayerCollider = GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("IsJumping", false); 
        animator.SetBool("enableAttack", false);    

        hm = FindObjectOfType<HealthManager>();
        ca = FindObjectOfType<CannonAttack>();
        

        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false; // 게임 시작 시 잔상 효과를 비활성화
    }

    void Update()
    {
        // 수평 입력을 받아옴
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpcount < 2 && canmove == true)
        {
            rb.velocity = Vector2.up * 22;
            jumpcount++;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetKeyDown(KeyCode.X)  && canmove == true) {

            animator.SetTrigger("IsAttacking");
        }



        if (Input.GetKeyDown(KeyCode.Z) && (Input.GetAxis("Horizontal") != 0) && !trailRenderer.enabled  && canmove == true)
        {
            isdash = true;
            animator.SetTrigger("IsDashing");
            StartDash();
            
        }

        if (dashtime <= 0)
        {
            defaultspeed = speed;
            if (isdash)
            {
                
                dashtime = defaulttime;
                
            }

        }
        else
        {
            dashtime -= Time.deltaTime;
            defaultspeed = dashspeed;
        }

        isdash = false;

        // 이동 입력에 따라 애니메이션 제어
        if (horizontalInput != 0f)

        {
            // 이동 입력이 있는 경우
            if (!animator.GetBool("IsMoving"))
            {
                // 애니메이션이 재생 중이 아닌 경우에만 재생
                animator.SetBool("IsMoving", true);
            }

            // 캐릭터 방향 설정
            if (horizontalInput < 0f)
            {
                // 왼쪽으로 이동하는 경우 캐릭터를 좌측으로 회전
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                Vector2 movement = new Vector2(horizontalInput, 0f) * -defaultspeed * Time.deltaTime;
                transform.Translate(movement);
            }
            else
            {
                // 오른쪽으로 이동하는 경우 캐릭터를 우측으로 회전
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Vector2 movement = new Vector2(horizontalInput, 0f) * defaultspeed * Time.deltaTime;
                transform.Translate(movement);
            }

            // 이동 벡터 계산

            // 현재 위치에 이동 벡터를 더하여 이동

        }
        else
        {
            // 이동 입력이 없는 경우
            if (animator.GetBool("IsMoving"))
            {
                // 애니메이션이 재생 중인 경우에만 정지
                animator.SetBool("IsMoving", false);
            }
        }

        
    }

    

    void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 11;

        //튕김 효과
        int dirc = transform.position.x-targetPos.x > 0 ? 1 : -1;
        rb.AddForce(new Vector2(dirc, 1)*12 ,ForceMode2D.Impulse);

        Invoke("OffDamaged", 2);
    }

    //무적 해제
    void OffDamaged()
    {
        gameObject.layer = 10;
    }

    private void StartDash()
    {
        // 대시 효과를 위해 Trail Renderer를 활성화하고 잔상을 그리도록 설정
        trailRenderer.enabled = true;
        trailRenderer.Clear(); // 이전 잔상 제거 (선택 사항)

        // 대시가 끝나는 시간이 지난 후에 대시 효과를 종료합니다.
        float dashDuration = 0.5f; // 대시 지속 시간
        StartCoroutine(StopDashAfterDuration(dashDuration));
    }

    private IEnumerator StopDashAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        // 대시가 끝났으므로 Trail Renderer를 비활성화합니다.
        trailRenderer.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpcount = 0;
        animator.SetBool("IsJumping", false);
        if(collision.gameObject.tag == "Enemy"){
            animator.SetTrigger("IsHurt");
            OnDamaged(collision.transform.position);
            StartCoroutine(hm.DecreaseHealthCoroutine(enemydamage));

            StartCoroutine(Unbeatable());
        }




    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Cannon"))
    {   
        animator.SetTrigger("IsHurt");
        OnDamaged(collision.transform.position);
        StartCoroutine(hm.DecreaseHealthCoroutine(cannondamage));

        StartCoroutine(Unbeatable());
    }
    }

    private IEnumerator Unbeatable()
    {
        yield return new WaitForSeconds(3f);

        
        PlayerCollider.enabled = true;
    }


    
    //무적 설정

}
