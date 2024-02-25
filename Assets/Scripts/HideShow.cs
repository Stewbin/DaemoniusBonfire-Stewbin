using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShow : MonoBehaviour
{
    public GameObject thisObject;

    void Start()
    {
        print("working"); 
    }

    
    void Update()
    {
        Hide(); 
    }

    public void Show()
    {
        thisObject.SetActive(true);

    }

    public void Hide()
    {
        thisObject.SetActive(false);

    }
}
