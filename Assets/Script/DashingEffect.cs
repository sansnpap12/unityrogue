using System.Collections;
using UnityEngine;

public class DashingEffect : MonoBehaviour
{
    private Animator animator;
    private bool canDash = true;
    public float dashCooldown = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (Input.GetAxis("Horizontal") != 0) && canDash)
        {
            StartCoroutine(PerformDashingEffect());
        }
    }

    IEnumerator PerformDashingEffect()
    {
        canDash = false;
        animator.SetTrigger("IsDashingEffect");

        // Wait for the cooldown time
        yield return new WaitForSeconds(dashCooldown);

        canDash = true; // Cooldown is over, allow dashing again.
    }
}
