using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageSystem : MonoBehaviour
{
    [SerializeField]
    public PlayerStats stats;
    public float RageRate = 5f;
    public Slider slider;

    void Start()
    {
        // Reset Rage bar to max 
        stats.CurrentRage = stats.MaxRage; 
        slider.maxValue = stats.MaxRage;
        slider.value = slider.maxValue;

        stats.currentState = States.Normal; // Reset state to Normal
    }


    void Update()
    {
        // Toggle 'Elkan is Mad' mode
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (stats.currentState != States.Rage)
            {
                stats.currentState = States.Rage;
            }
            else 
            {
                stats.currentState = States.Normal;
            }
                
        }
        // Turn to normal state if Rage == 0
        if (stats.CurrentRage == 0) {stats.currentState = States.Normal;}

        // Burn through rage meter if in Mad mode
        if (stats.currentState == States.Rage)
        {
            stats.CurrentRage -= RageRate * Time.deltaTime;
            slider.value = stats.CurrentRage;
        }

    }
}
