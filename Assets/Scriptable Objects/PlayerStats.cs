using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField]
    public float maxHealth = 100;
    public float currentHealth;
   
    public float MaxRage = 80;
    public float CurrentRage;

    public States currentState;
}

public enum States
{
    Rage,
    Normal
}