using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyTrigger : MonoBehaviour
{
    public bool isColliding = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        // 충돌한 객체가 플레이어인 경우에만 상태를 true로 설정합니다.
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 충돌한 객체가 플레이어인 경우에만 상태를 true로 설정합니다.
        if (other.CompareTag("Player"))
        {
            isColliding = false;
            
        }
    }

}
