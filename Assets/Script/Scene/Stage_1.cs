using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public string stage_1;
    public void SceneChange()
    {
        SceneManager.LoadScene("stage_1");

    }
}
