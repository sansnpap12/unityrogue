using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public string tutorial;
    public void SceneChange()
    {
        SceneManager.LoadScene("Tutorial");

    }

}