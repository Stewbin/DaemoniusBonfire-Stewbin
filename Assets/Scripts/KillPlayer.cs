using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{ 
    private string CurrentScene ;

    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().name;
    }

    // Reloads the current scene
    // *dying & restarting
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("InstaDeath"))
        {
            SceneManager.LoadScene(CurrentScene);
        }
    }
}
