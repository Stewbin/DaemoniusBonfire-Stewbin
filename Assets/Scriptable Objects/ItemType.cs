using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemType", menuName = "Spawnable Objects/Items", order = 0)]
public class ItemType : ScriptableObject
{
	public string ItemName;
	public int HealthDamageIncrease;
	public bool CanStack;
	
	
}

