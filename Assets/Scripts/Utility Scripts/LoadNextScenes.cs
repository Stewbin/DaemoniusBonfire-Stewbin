using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Load all connected scenes within a chunk
public class LoadConnectedScenes : MonoBehaviour
{
    [SerializeField] private SceneField[] ConnectedScenes; 
       
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadScenes();
        }
    }  

    private void LoadScenes()
    {
        foreach (SceneField scene in ConnectedScenes)
        {
            // Check if scene is already loaded
            bool IsLoaded = false;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(i);
                // If scene is found in active scenes
                if (scene.SceneName.Equals(loadedScene.name))
                {
                    IsLoaded = true;
                    break;
                }
            }
            
            if (!IsLoaded) // If not loaded
            {
                SceneManager.LoadSceneAsync(scene.SceneName, LoadSceneMode.Additive);
                Debug.Log($"{scene.SceneName} was loaded");
            }
        }
    }

    private void UnloadScene() 
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene activeScene = SceneManager.GetSceneAt(i);
            bool NeedToUnload = false;

            foreach (SceneField connectedScene in ConnectedScenes)
            {
                // If there are active scenes besides ones in the chunk
                if (!activeScene.name.Equals(connectedScene.SceneName))
                {
                    NeedToUnload = true;
                }
            }
            if (NeedToUnload)
            {
                SceneManager.UnloadSceneAsync(activeScene);
            }
        }
    }
}
