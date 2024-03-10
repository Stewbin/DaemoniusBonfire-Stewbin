using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField]
    public PlayerStats stats; 
    public Slider slider; 
    
    // Start is called before the first frame update
    void Start()
    {
        stats.CurrentStamina = stats.MaxStamina;
        slider.maxValue = stats.MaxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        // Update slider value
        slider.value = stats.CurrentStamina;
    }
}
