using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/patrol")]
public class Patrol : Action
{
	public override void Execute(BaseStateMachine stateMachine)
	{
		//patrol state 
		Debug.Log("patrolling");
		stateMachine.GetComponent<SpriteRenderer>().color = Color.green;
	}
    public override string ToString()
    {
        return "patrolling state";
    }
}
