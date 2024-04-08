using System.Collections;
using System.Collections.Generic;
// using System.Drawing.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script should be attached to the player GObject
public class KillPlayer : MonoBehaviour
{ 
    private string CurrentScene;

    void Start()
    {
        // Will fetch the name of the current scene as a string
        CurrentScene = SceneManager.GetActiveScene().name;
    }

    // Reloads the current scene
    // *dying & restarting
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Will kill player if they touch something tagged InstaDeath
        if(collision.gameObject.la)
        {
            KillElkan();   
        }
    }

    public void KillElkan()
    {
        SceneManager.LoadScene(CurrentScene);
        Debug.Log("Elkan has died");
    }
}
