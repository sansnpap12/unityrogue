using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skill_select_1 : MonoBehaviour
{   

    public string skill_select_1;
 
    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {   
            SceneManager.LoadScene("skill_select_1");
            
        }
    }

}
