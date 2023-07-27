using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthManager : MonoBehaviour
{
    public Image healthbar; // 로딩 바 이미지
    private RectTransform rectComponent;

    public TextMeshProUGUI healthnum;


    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        healthbar = rectComponent.GetComponent<Image>();
        healthnum = transform.Find("health_text").GetComponent<TextMeshProUGUI>();

    }

    void Update() {

        
        string strhealth = healthnum.text;
        float flohealth = float.Parse(strhealth);
        healthbar.fillAmount = flohealth/100f;

    }

    public IEnumerator DecreaseHealthCoroutine(float damage)
    {
        string strhealth = healthnum.text;
        float flohealth = float.Parse(strhealth);
        
        if (flohealth > 0)
        {
            flohealth -= damage;
            healthnum.text = flohealth.ToString();
        }

        yield return null; // 한 프레임 기다리기
    }
    
}
