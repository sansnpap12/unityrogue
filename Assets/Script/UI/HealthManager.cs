using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private Image healthbar; // 로딩 바 이미지
    private RectTransform rectComponent;

    [SerializeField]
    private TextMeshProUGUI healthnum;
    public float temphealth = 100f;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        healthbar = rectComponent.GetComponent<Image>();
        healthnum = transform.Find("health_text").GetComponent<TextMeshProUGUI>();

        // 이전 씬에서 저장한 temphealth 값을 가져옵니다.
        temphealth = PlayerPrefs.GetFloat("TempHealth", 100f);

        healthnum.text = temphealth.ToString();
    }

    private void Update()
    {
        string strhealth = healthnum.text;
        float flohealth = float.Parse(strhealth);
        healthbar.fillAmount = flohealth / 100f;

        temphealth = float.Parse(healthnum.text);

        Debug.Log(temphealth);
    }

    public IEnumerator DecreaseHealthCoroutine(float damage)
    {
        string strhealth = healthnum.text;
        float flohealth = float.Parse(strhealth);

        if (flohealth > 0)
        {
            flohealth -= damage;
            healthnum.text = flohealth.ToString();

            temphealth = flohealth;

            // 변경된 temphealth 값을 저장합니다.
            PlayerPrefs.SetFloat("TempHealth", temphealth);
        }

        yield return null; // 한 프레임 기다리기
    }

    private void OnApplicationQuit()
    {
        // 애플리케이션이 종료될 때 TempHealth 값을 초기화합니다.
        PlayerPrefs.DeleteKey("TempHealth");
    }
}
