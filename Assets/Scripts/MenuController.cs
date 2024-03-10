using System.Collections;
using System.Collections.Generic;
using Cinemachine.PostFX;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private int LastSave = 1; // Last scene saved at (will be "Steven" by default)
    private GameObject optionsPanel;
    private GameObject titlePanel;

    void Start()
    {
        optionsPanel = GameObject.Find("Options Panel");
        titlePanel = GameObject.Find("Title Panel");

        optionsPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Steven"); // Loads the 2nd scene (theoretically)
    }

    public void Continue()
    {
        SceneManager.LoadScene(LastSave);
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
        titlePanel.SetActive(false);
        // Debug.Log("options was pressed");
    }
    
    // Quits the game in a build
    public void QuitGame()
    {
        Application.Quit();
    }
}
