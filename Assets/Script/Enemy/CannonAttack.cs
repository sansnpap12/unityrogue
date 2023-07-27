using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // 포탄 프리팹
    private float spawnPeriod = 2f; // 포탄 생성 주기 (초 단위)
    private float projectileLifetime = 2f; // 포탄 생존 시간 (초 단위)
    private int projectileSortingOrder = 13; // 포탄의 Order in Layer 값

    public bool shell_visible = true;

    private HealthManager hm;

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnPeriod;
        hm = FindObjectOfType<HealthManager>();
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnProjectile();
            nextSpawnTime = Time.time + spawnPeriod;
        }
    }

    private void SpawnProjectile()
    {
        shell_visible = true;
        
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        BoxCollider2D boxCollider = projectile.AddComponent<BoxCollider2D>();

        // 추가한 충돌체의 크기 설정 (원하는 크기로 수정)
        boxCollider.size = new Vector2(0.3f, 0.3f);

        // 추가한 충돌체의 오프셋 설정 (원하는 위치로 수정)
        boxCollider.offset = new Vector2(0f, 0f);
  
        // 포탄의 Order in Layer 설정
        SpriteRenderer spriteRenderer = projectile.GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            spriteRenderer.sortingOrder = projectileSortingOrder;
        }

        // 하위 오브젝트의 Order in Layer 설정
        SpriteRenderer childRenderer = projectile.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (childRenderer)
        {
            childRenderer.sortingOrder = projectileSortingOrder + 1;
        }


        // 생성된 포탄을 일정 시간 후에 제거하는 코루틴 실행
        StartCoroutine(DestroyProjectileAfterTime(projectile, projectileLifetime));

        // 포탄 발사 (왼쪽 방향으로 이동)
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb)
        {
            rb.velocity = Vector2.left * 5f; // 원하는 속도로 조절
        }

        
    }

    // 일정 시간 후에 포탄을 제거하는 코루틴 함수
    public IEnumerator DestroyProjectileAfterTime(GameObject projectile, float delay)
    {   
        yield return new WaitForSeconds(delay);
        Destroy(projectile);
    }

    


}
