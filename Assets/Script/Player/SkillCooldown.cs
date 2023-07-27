using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    public Image z_cooldown;
    public Image d_cooldown;
    public Image s_cooldown;

    private float z_cooltime = 0.5f;
    private float d_cooltime = 1f;
    private float s_cooltime = 2f;

    void Start()
    {
        z_cooldown = GameObject.Find("z_cooldown").GetComponent<Image>();
        d_cooldown = GameObject.Find("d_cooldown").GetComponent<Image>();
        s_cooldown = GameObject.Find("s_cooldown").GetComponent<Image>();

        z_cooldown.fillAmount = 0f;
        d_cooldown.fillAmount = 0f;
        s_cooldown.fillAmount = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && z_cooldown.fillAmount == 0f && (Input.GetAxis("Horizontal") != 0))
        {
            StartCoroutine(ZCooldown());
        }
        else if (Input.GetKeyDown(KeyCode.D) && d_cooldown.fillAmount == 0f)
        {
            StartCoroutine(DCooldown());
        }
        else if (Input.GetKeyDown(KeyCode.S) && s_cooldown.fillAmount == 0f)
        {
            StartCoroutine(SCooldown());
        }
    }

    IEnumerator ZCooldown()
    {
        float timer = z_cooltime;

        while (timer > 0f)
        {
            float progress = timer / z_cooltime;
            z_cooldown.fillAmount = progress;

            timer -= Time.deltaTime;

            yield return null;
        }

        z_cooldown.fillAmount = 0f;
    }

    IEnumerator DCooldown()
    {
        float timer = d_cooltime;

        while (timer > 0f)
        {
            float progress = timer / d_cooltime;
            d_cooldown.fillAmount = progress;

            timer -= Time.deltaTime;

            yield return null;
        }

        d_cooldown.fillAmount = 0f;
    }

    IEnumerator SCooldown()
    {
        float timer = s_cooltime;

        while (timer > 0f)
        {
            float progress = timer / s_cooltime;
            s_cooldown.fillAmount = progress;

            timer -= Time.deltaTime;

            yield return null;
        }

        s_cooldown.fillAmount = 0f;
    }
}
