using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//left and right up or doen
public class PatrollScript : MonoBehaviour
{
	// Start is called before the first frame update
	public PatrollType patroll;

	// Update is called once per frame
	private void Awake() { 
		// patroll.moveTowards = new Vector2()
	}

	public void Move()
	{
		patroll.move(gameObject);
	}
}
