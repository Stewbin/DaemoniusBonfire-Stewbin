using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PauseController : MonoBehaviour
{
    [SerializeField] 
    public GameObject overlay;
    public bool paused = false;  


    void Start()
    {
        ResumeGame(); // Makes sure the game starts resumed
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                PauseGame();
            }
            else 
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        overlay.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void ResumeGame()
    {
        overlay.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        Debug.Log("Resume button was pressed");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MM button was pressed");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
