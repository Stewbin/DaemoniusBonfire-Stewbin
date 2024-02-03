using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseController : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    public bool paused = false;  

    void Awake()
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
