using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElkanHealth : MonoBehaviour
{

	public PlayerStats p; //over haul we create either a local script with the player health
						  //or a scriptable object with player health >:] dwabtit
	void Awake()
	{
		p.currentHealth = 100;
	}
	void Update()
	{
		if (p.currentHealth < 100)
		{
			Debug.Log("player dead");
			// p.currentHealth = 100;
			
		}
	}
	// Start is called before the first frame update
	private void OnCollisionEnter2D(Collision2D other)
	{
		int L = other.gameObject.layer;
		if (L == LayerMask.NameToLayer("damageLayer"))
		{
			if (other.gameObject.GetComponent<DamageDealtStats>() == null) return;
			p.currentHealth -= other.gameObject.GetComponent<DamageDealtStats>().Damage;
			Debug.Log(p.currentHealth);
		}

	}
}
