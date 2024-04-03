using System;
using UnityEngine;
public class EyeSensor : MonoBehaviour
{
	//shoots ray and tells you if player hing you want to attack is in site s
	public GameObject Targets;
	// public Ray 
	private void Start()
	{
	}
	private void Update()
	{
		// // int n = 0;
		// if (GetComponent<SpriteRenderer>().flipX)
		// 	n = -1;
		// else
		// 	n = 1;
		// transform.LookAt(new Vector2(0,0));

		// Debug.DrawRay(transform.position,, Color.green); //debugging purposes
	}
	public bool isNear()
	{
		// Debug.DrawRay(position, direction * 3.0f, Color.green); //debugging purposes
		return false;

	}


}