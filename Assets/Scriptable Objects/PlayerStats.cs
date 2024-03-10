using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField]
    // Health bar
    public float maxHealth = 100;
    public float currentHealth;
    // Rage bar
    public float MaxRage = 80;
    public float CurrentRage;
    // Stamina Bar
    public float MaxStamina = 1000f;
    public float CurrentStamina; 

    public States currentState;
}

public enum States
{
    Rage,
    Normal
}