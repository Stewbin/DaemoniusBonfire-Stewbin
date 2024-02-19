using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T instance
    {
        set
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                _instance = go.AddComponent<T>();
                go.name = typeof(T).ToString() + " singleton";
                DontDestroyOnLoad(go);
            }
        }
        get {return _instance;}
    }


}
