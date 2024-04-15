using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class HealthSystemAdapted : MonoBehaviour
{
	[SerializeField]
	public PlayerStats stats;
	public Slider slider; // For accessing the health bar's slider
	public KillPlayer death;


	void Start()
	{
		// Maximum health amount set to 100
		stats.currentHealth = stats.maxHealth;
		slider.maxValue = stats.currentHealth;
	}

	public void damageTaken(float damage)
	{
		stats.currentHealth -= damage;

		if (stats.currentHealth <= 0)
		{
			//Player Dies 
			death.KillElkan();
			print("Elkan is dead");
		}
	}

	void Update()
	{
		// if (Input.GetKeyDown(KeyCode.Space)) {damageTaken(10);}
		if (stats.currentHealth <= 0)
		{
			death.KillElkan();
			// stats.currentHealth -
		}
		slider.value = stats.currentHealth;
		//Mathf.Clamp(stats.currentHealth / stats.maxHealth, 0, 1);
	}

}
