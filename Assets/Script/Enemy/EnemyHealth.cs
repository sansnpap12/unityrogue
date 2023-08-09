// EnemyHealth 스크립트
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{

    private Image healthbar;
    private RectTransform rectComponent;

    private TextMeshProUGUI healthnum; // static_health TextMeshProUGUI 변수 추가
    private float fullhealth;


    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        healthbar = rectComponent.GetComponent<Image>();
        healthnum = transform.Find("health_text").GetComponent<TextMeshProUGUI>();

        fullhealth = float.Parse(healthnum.text);

    }

    public void Update() {

        string strhealth = healthnum.text;
        float flohealth = float.Parse(strhealth);
        healthbar.fillAmount = flohealth / fullhealth;

    }

    public IEnumerator DecreaseHealthByAmount(float damage)
    {
        string strhealth = healthnum.text;
        float flohealth = float.Parse(strhealth);

        if (flohealth > 0)
        {
            flohealth -= damage;
            healthnum.text = flohealth.ToString();
        }

        Debug.Log("1번 들어옴");

        yield return null; 
    }
}
