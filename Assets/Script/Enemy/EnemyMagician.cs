using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagician : MonoBehaviour
{
    public GameObject waterbulletPrefab;
    private Transform target;
    private LongEnemyTrigger LET; // Player 스크립트를 참조하기 위한 변수
    private bool isShooting = false; // Flag to prevent infinite shooting

    void Start()
    {
        LET = FindObjectOfType<LongEnemyTrigger>(); // Player 스크립트를 가진 오브젝트를 찾아서 player 변수에 저장
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is colliding with this enemy before attacking
        if (LET.isColliding && !isShooting)
        {
            // Call the coroutine to handle shooting and delay
            StartCoroutine(ShootWithDelay());
        }
    }

    // Coroutine to shoot with a delay
    private IEnumerator ShootWithDelay()
    {
        isShooting = true; // Set the flag to prevent multiple coroutines

        // Calculate the new position shifted up and left by 1.0 unit
        Vector3 spawnPosition = transform.position + Vector3.left * 1.0f + Vector3.up * 0.5f;

        // Instantiate the waterbullet prefab
        GameObject waterbullet = Instantiate(waterbulletPrefab, spawnPosition, transform.rotation);

        // Wait for 0.5 seconds
        yield return new WaitForSeconds(2f);

        isShooting = false; // Reset the flag to allow shooting again
    }
}
