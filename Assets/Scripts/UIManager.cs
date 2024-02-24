using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject HUD;
    public GameObject PauseMenu;
    
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
       
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Instantiate UI Elements
        if (scene.name != "MainMenu")
        {
            PrefabUtility.InstantiatePrefab(HUD);
            PrefabUtility.InstantiatePrefab(PauseMenu);
        }
        Debug.Log("new scene laoded");
    }

}
