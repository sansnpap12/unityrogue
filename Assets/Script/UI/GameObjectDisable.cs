using UnityEngine;

public class GameObjectDisable : MonoBehaviour
{
    public GameObject[] objectsToDisable; // 비활성화할 게임 오브젝트 배열
    public GameObject StartButton;
    public GameObject OptionButton;
    public GameObject EndButton;
    public GameObject Title;

    public GameObject[] objectsToEnable;
    public GameObject[] DisableObj;
    
    public GameObject NextButton;

    

    public void Start()
    {

        DisableObj = new GameObject[] {NextButton};
        foreach (GameObject obj in DisableObj)
        {
            obj.SetActive(false);
        }




    }
    public void DisableObjects()
    {

        objectsToDisable = new GameObject[] { StartButton, OptionButton, EndButton,Title};
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }


        objectsToEnable = new GameObject[] {NextButton};
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }



    }
}